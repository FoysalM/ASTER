using System;
using System.Collections.Generic;

namespace uni.api.Models
{
    public partial class LecturerCourse
    {
        public int LecCoursId { get; set; }
        public int? LecId { get; set; }
        public int? CoursId { get; set; }

        public virtual Course Cours { get; set; }
        public virtual Lecturer Lec { get; set; }
    }
}
