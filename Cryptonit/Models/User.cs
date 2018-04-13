using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Cryptonit.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required!")]
        public string name { get; set; }

        [Required(ErrorMessage = "Surname is required!")]
        public string surname { get; set; }

        [Required(ErrorMessage = "Login is required!")]
        public string login { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Compare("password", ErrorMessage ="Pleas confirm your password.")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        public string email { get; set; }
    }



}
