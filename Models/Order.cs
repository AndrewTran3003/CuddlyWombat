using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public class Order:Entity
    {
        public string OrderType { get; set; }
        public double AmountDue { get; set; }
        public string Status { get; set; }
        public string Employee { get; set; }
        public string CustomerName { get; set; }
        public ICollection<OrderJItem> OrderItems { get; set; }
        public ICollection<OrderJMenu> OrderMenus { get; set; }

        public bool IsPaid { get; set; }
        public DateTime OrderStartTime { get; set; }
        public PaymentJOrder PaymentOrder { get; set; }

    }
}
