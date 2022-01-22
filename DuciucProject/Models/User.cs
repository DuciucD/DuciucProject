using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuciucProject.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public UserType UserType { get; set; }

        public virtual ICollection<Milestone> Milestones { get; set; }

        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }
    }

    public enum UserType
    {
        [Description("Project manager")]
        ProjectManager,
        [Description("Expert")]
        Expert,
        [Description("Rollout manager")]
        RolloutManager
    }
}
