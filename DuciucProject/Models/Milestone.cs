using System.Collections.Generic;

namespace DuciucProject.Models
{
    public class Milestone
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
