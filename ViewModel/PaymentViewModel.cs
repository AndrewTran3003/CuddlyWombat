using CuddlyWombat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.ViewModel
{
    public class PaymentViewModel
    {
        public Payment Payment { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public OrderViewModel ActiveOrder { get; set; }

    }
}
