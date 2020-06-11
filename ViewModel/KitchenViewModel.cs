using CuddlyWombat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.ViewModel
{
    public class KitchenViewModel
    {
        public IEnumerable<Order> OrdersToBeFinished { get; set; }
    }
}
