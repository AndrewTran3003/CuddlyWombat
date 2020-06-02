using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public class Payment:Entity
    {
        public double Amount { get; set; }
        public string Method { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public PaymentJOrder PaymentOrder { get; set; }
        public PaymentJReceipt PaymentReceipt { get; set; }
    }
}
