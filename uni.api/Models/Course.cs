using System;
using System.Collections.Generic;

namespace uni.api.Models
{
    public partial class Course
    {
        public Course()
        {
            LecturerCourse = new HashSet<LecturerCourse>();
            Module = new HashSet<Module>();
            Student = new HashSet<Student>();
        }

        public int CoursId { get; set; }
        public int? LecId { get; set; }
        public string CoursName { get; set; }
        public int? ModQty { get; set; }

        public virtual ICollection<LecturerCourse> LecturerCourse { get; set; }
        public virtual ICollection<Module> Module { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
