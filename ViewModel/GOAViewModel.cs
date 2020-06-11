using CuddlyWombat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.ViewModel
{
    public class GOAViewModel
    {
        public IEnumerable<Order> LateOrders { get; set; }
        public IEnumerable<Item> GOAItems { get; set; }
        public Order ActiveLateOrder{ get; set; }
    }
}
