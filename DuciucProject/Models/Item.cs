using System;
using System.Collections.Generic;

namespace DuciucProject.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public virtual ICollection<TaskComment> Comments { get; set; }

        public int MilestoneId { get; set; }

        public Milestone Milestone { get; set; }
    }
}
