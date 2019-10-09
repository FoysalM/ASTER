using System;
using System.Collections.Generic;

namespace uni.api.Models
{
    public partial class StudentAssignment
    {
        public int StuAssignId { get; set; }
        public int? StuId { get; set; }
        public int? AssignId { get; set; }

        public virtual Assignment Assign { get; set; }
        public virtual Student Stu { get; set; }
    }
}
