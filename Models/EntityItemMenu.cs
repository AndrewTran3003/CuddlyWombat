using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public class EntityItemMenu:Entity
    {
        public string Type { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
