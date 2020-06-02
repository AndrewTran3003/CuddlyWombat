using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public class ItemJMenu:EntityJoin
    {
        public Guid MenuID { get; set; }
        public Guid ItemID { get; set; }

        public Item Item { get; set; }
        public Menu Menu { get; set; }
    }
}
