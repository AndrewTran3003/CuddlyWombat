using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public class SystemUserRegistration
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassWord { get; set; }

        [Required]
        [Display(Name = "User Role")]
        public string UserRole { get; set; }
    }
}
