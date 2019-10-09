using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace uni.api.Models
{
    public partial class unidb01Context : DbContext
    {
        public unidb01Context()
        {
        }

        public unidb01Context(DbContextOptions<unidb01Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignment { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Lecturer> Lecturer { get; set; }
        public virtual DbSet<LecturerCourse> LecturerCourse { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentAssignment> StudentAssignment { get; set; }
        public virtual DbSet<University> University { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=aster01.database.windows.net;Initial Catalog=unidb01;Integrated Security=False;Persist Security Info=True;User ID=asterAdmin01;Password=B1swanath");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => e.AssignId);

                entity.Property(e => e.AssignId)
                    .HasColumnName("assignID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AssignName)
                    .HasColumnName("assignName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnName("endDate");

                entity.Property(e => e.ModId).HasColumnName("modID");

                entity.Property(e => e.StartDate).HasColumnName("startDate");

                entity.HasOne(d => d.Mod)
                    .WithMany(p => p.Assignment)
                    .HasForeignKey(d => d.ModId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Assignment_Module");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CoursId);

                entity.Property(e => e.CoursId)
                    .HasColumnName("coursID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CoursName)
                    .HasColumnName("coursName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LecId).HasColumnName("lecID");

                entity.Property(e => e.ModQty).HasColumnName("modQty");
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.HasKey(e => e.LecId);

                entity.Property(e => e.LecId)
                    .HasColumnName("lecID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FName)
                    .HasColumnName("fName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.Property(e => e.SName)
                    .HasColumnName("sName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Lecturer)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Lecturer_Role");
            });

            modelBuilder.Entity<LecturerCourse>(entity =>
            {
                entity.HasKey(e => e.LecCoursId);

                entity.Property(e => e.LecCoursId)
                    .HasColumnName("lecCoursID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CoursId).HasColumnName("coursID");

                entity.Property(e => e.LecId).HasColumnName("lecID");

                entity.HasOne(d => d.Cours)
                    .WithMany(p => p.LecturerCourse)
                    .HasForeignKey(d => d.CoursId)
                    .HasConstraintName("FK_LecturerCourse_Course");

                entity.HasOne(d => d.Lec)
                    .WithMany(p => p.LecturerCourse)
                    .HasForeignKey(d => d.LecId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_LecturerCourse_Lecturer");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.Property(e => e.LoginId)
                    .HasColumnName("loginID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Login_Role");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.ModId);

                entity.Property(e => e.ModId)
                    .HasColumnName("modID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AssignQty).HasColumnName("assignQty");

                entity.Property(e => e.CoursId).HasColumnName("coursID");

                entity.Property(e => e.ModName)
                    .HasColumnName("modName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cours)
                    .WithMany(p => p.Module)
                    .HasForeignKey(d => d.CoursId)
                    .HasConstraintName("FK_Module_Course");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .HasColumnName("roleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleType)
                    .HasColumnName("roleType")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StuId);

                entity.Property(e => e.StuId)
                    .HasColumnName("stuID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CoursId).HasColumnName("coursID");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FName)
                    .HasColumnName("fName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.Property(e => e.SName)
                    .HasColumnName("sName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cours)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.CoursId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Student_Course");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Student_Role");
            });

            modelBuilder.Entity<StudentAssignment>(entity =>
            {
                entity.HasKey(e => e.StuAssignId);

                entity.Property(e => e.StuAssignId)
                    .HasColumnName("stuAssignID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AssignId).HasColumnName("assignID");

                entity.Property(e => e.StuId).HasColumnName("stuID");

                entity.HasOne(d => d.Assign)
                    .WithMany(p => p.StudentAssignment)
                    .HasForeignKey(d => d.AssignId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_StudentAssignment_Assignment");

                entity.HasOne(d => d.Stu)
                    .WithMany(p => p.StudentAssignment)
                    .HasForeignKey(d => d.StuId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_StudentAssignment_Student");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.HasKey(e => e.UniId);

                entity.Property(e => e.UniId)
                    .HasColumnName("uniID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UniName)
                    .HasColumnName("uniName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
