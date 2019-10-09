using System;
using System.Collections.Generic;

namespace uni.api.Models
{
    public partial class Login
    {
        public int LoginId { get; set; }
        public int? RoleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Role Role { get; set; }
    }
}
