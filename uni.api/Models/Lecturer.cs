using System;
using System.Collections.Generic;

namespace uni.api.Models
{
    public partial class Lecturer
    {
        public Lecturer()
        {
            LecturerCourse = new HashSet<LecturerCourse>();
        }

        public int LecId { get; set; }
        public int? RoleId { get; set; }
        public string Title { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }
        public string Email { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<LecturerCourse> LecturerCourse { get; set; }
    }
}
