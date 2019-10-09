using System;
using System.Collections.Generic;

namespace uni.api.Models
{
    public partial class Role
    {
        public Role()
        {
            Lecturer = new HashSet<Lecturer>();
            Login = new HashSet<Login>();
            Student = new HashSet<Student>();
        }

        public int RoleId { get; set; }
        public string RoleType { get; set; }

        public virtual ICollection<Lecturer> Lecturer { get; set; }
        public virtual ICollection<Login> Login { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
