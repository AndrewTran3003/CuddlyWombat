using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public class PaymentJOrder:EntityJoin
    {
        public Guid PaymentID { get; set; }
        public Guid OrderID { get; set; }
        public Payment Payment { get; set; }
        public Order Order { get; set; }
    }
}
