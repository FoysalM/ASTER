using System;
using System.Collections.Generic;

namespace uni.api.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentAssignment = new HashSet<StudentAssignment>();
        }

        public int StuId { get; set; }
        public int? CoursId { get; set; }
        public int? RoleId { get; set; }
        public string Title { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }
        public string Email { get; set; }

        public virtual Course Cours { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<StudentAssignment> StudentAssignment { get; set; }
    }
}
