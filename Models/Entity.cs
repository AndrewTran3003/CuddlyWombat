using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public abstract class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        
        //TODO: Method that allows an entity to return an instance of itself


    }
}
