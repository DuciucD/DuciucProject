using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuciucProject.Models
{
    public class TaskComment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Comment is mandatory")]
        [StringLength(200, MinimumLength = 7)]
        public string Comment { get; set; }

        [DisplayName("Added date")]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        [DisplayName("Updated date")]
        [DataType(DataType.Date)]
        public DateTime? UpdatedDate { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
