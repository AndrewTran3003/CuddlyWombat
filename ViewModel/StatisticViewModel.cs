using CuddlyWombat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.ViewModel
{
    public class StatisticViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<Menu> Menus { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }  
}
