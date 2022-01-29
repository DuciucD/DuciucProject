using DuciucProject.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using System.Reflection;

namespace DuciucProject.Models
{
    public class User
    {
        public int Id { get; set; }

        [DisplayName("First name")]
        [Required(ErrorMessage = "First name is mandatory")]
        [RegularExpression(Constants.RegexStartsWithCapitalLetter, ErrorMessage = "Name must start with capital letter followed by lower case letter")]
        [StringLength(30,MinimumLength = 5)]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [RegularExpression(Constants.RegexStartsWithCapitalLetter, ErrorMessage = "Name must start with capital letter followed by lower case letter")]
        [Required(ErrorMessage = "LastLast name is mandatory")]
        [StringLength(30, MinimumLength = 5)]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage = "Email is mandatory")]
        public string Email { get; set; }

        [DisplayName("User type")]
        [Required(ErrorMessage = "User type is mandatory")]
        public UserType UserType { get; set; }

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
