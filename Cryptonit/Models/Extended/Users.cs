using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cryptonit.Models
{
    [MetadataType(typeof(UsersMetadata))]
    public partial class Users
    {
        public string confirmPassword { get; set; }
    }
    public class UsersMetadata
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required!")]
        public string name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Surname is required!")]
        public string surname { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Login is required!")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "Login must be between 7 and 50 letters")]
        public string login { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        [MinLength(7, ErrorMessage = "The Password must be the least 7 characters long.")]
        public string password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("password", ErrorMessage = "Pleas confirm your password.")]
        [DataType(DataType.Password)]
        [MinLength(7, ErrorMessage = "The Password must be the least 7 characters long.")]
        public string confirmPassword { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email address is not correct.")]
        public string email { get; set; }
    }
}