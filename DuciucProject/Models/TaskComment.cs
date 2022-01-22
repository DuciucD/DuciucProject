using System;

namespace DuciucProject.Models
{
    public class TaskComment
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
