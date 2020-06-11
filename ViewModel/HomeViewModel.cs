using CuddlyWombat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<Menu> Menus { get; set; }
    }
}
