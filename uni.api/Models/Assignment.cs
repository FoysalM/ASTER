using System;
using System.Collections.Generic;

namespace uni.api.Models
{
    public partial class Assignment
    {
        public Assignment()
        {
            StudentAssignment = new HashSet<StudentAssignment>();
        }

        public int AssignId { get; set; }
        public int? ModId { get; set; }
        public string AssignName { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public virtual Module Mod { get; set; }
        public virtual ICollection<StudentAssignment> StudentAssignment { get; set; }
    }
}
