using System;
using System.Collections.Generic;

namespace uni.api.Models
{
    public partial class Module
    {
        public Module()
        {
            Assignment = new HashSet<Assignment>();
        }

        public int ModId { get; set; }
        public int? CoursId { get; set; }
        public string ModName { get; set; }
        public int? AssignQty { get; set; }

        public virtual Course Cours { get; set; }
        public virtual ICollection<Assignment> Assignment { get; set; }
    }
}
