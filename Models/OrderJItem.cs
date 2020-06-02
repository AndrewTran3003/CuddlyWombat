using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public class OrderJItem:EntityJoin
    {
        public Guid ItemID { get; set; }
        public Guid OrderID { get; set; }
        public Item Item { get; set; }
        public Order Order { get; set; }
        public int ItemsSold { get; set; }
    }
}
