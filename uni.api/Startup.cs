using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using uni.api.Models;

namespace uni.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /* Added CORS for dev and testing, in production, cross origin will only be set to allow requests from
             * ASTER website only. */
            services.AddCors(options =>
            {
            options.AddPolicy("AllowASTEROrigin", builder => builder.WithOrigins("http://localhost:59679")
                                                                 .AllowAnyHeader()
                                                                 .AllowAnyMethod()
                                                                 .AllowCredentials());
            });

            /* Added dbContext service to call database requests by aster components, currently the connectionstring
             * has been auto-included in the dbcontext file by entity framework. This will need to be moved to the 
             * appsettings file for added security. Additionally, the dbcontext service will need to be modified also. */
            services.AddDbContext<unidb01Context>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Added UseCors to call AllowASTEROrigin
            app.UseCors("AllowASTEROrigin");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
