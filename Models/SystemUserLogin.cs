using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public class SystemUserLogin
    {
        [Required]
        [Display(Name = "User Name")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }


        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
