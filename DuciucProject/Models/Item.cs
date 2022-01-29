using DuciucProject.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DuciucProject.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is mandatory")]
        [RegularExpression(Constants.RegexStartsWithCapitalLetter, ErrorMessage = "Name must start with capital letter followed by lower case letter")]
        [StringLength(50, MinimumLength = 7)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [DisplayName("Start date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayName("Due date")]
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        public virtual ICollection<TaskComment> Comments { get; set; }

        public int MilestoneId { get; set; }

        public Milestone Milestone { get; set; }
    }
}
