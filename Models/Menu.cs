using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public class Menu:EntityItemMenu
    {
        public ICollection<ItemJMenu> ItemMenus { get; set; }
        public ICollection<OrderJMenu> OrderMenus { get; set; }
        
    }
}
