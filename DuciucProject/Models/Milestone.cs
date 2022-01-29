using DuciucProject.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DuciucProject.Models
{
    public class Milestone
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is mandatory")]
        [RegularExpression(Constants.RegexStartsWithCapitalLetter, ErrorMessage = "Name must start with capital letter followed by lower case letter")]
        [StringLength(50, MinimumLength = 7)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
