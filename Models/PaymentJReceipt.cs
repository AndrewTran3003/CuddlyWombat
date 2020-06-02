using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public class PaymentJReceipt:EntityJoin
    {
        public Guid ReceiptID { get; set; }
        public Guid PaymentID { get; set; }
        public Payment Payment { get; set; }
        public Receipt Receipt { get; set; }
    }
}
