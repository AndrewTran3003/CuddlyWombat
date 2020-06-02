using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public class OrderJMenu:EntityJoin
    {
        public Guid MenuID { get; set; }
        public Guid OrderID { get; set; }
        public Menu Menu { get; set; }
        public Order Order { get; set; }
        public int MenusSold { get; set; }
    }
}
