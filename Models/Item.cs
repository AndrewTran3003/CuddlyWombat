using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public class Item : EntityItemMenu
    {
        public ICollection<ItemJMenu> ItemMenus {get;set;}
        public ICollection<OrderJItem> OrderItems { get; set; }
    }
}
