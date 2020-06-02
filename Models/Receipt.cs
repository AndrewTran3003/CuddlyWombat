using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public class Receipt:Entity
    {
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Display(Name = "Merchant ID")]
        public string MerchantID { get; set; }

        [Display(Name = "Item List")]
        public string OrderDetail { get; set; }
        public double Total { get; set; }
        public PaymentJReceipt PaymentReceipt { get; set; }

    }
}
