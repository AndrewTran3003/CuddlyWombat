using CuddlyWombat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.ViewModel
{
    public class ReceiptViewModel
    {
        public ICollection<Receipt> Receipts { get; set; }
        public Receipt CurrentReceipt { get; set; }
        public string ActiveOrderID { get; set; }
    }
}
