using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.API.Domain.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerUnit { get; set; }
        public string Type { get; set; }
        public string ModelNumber { get; set; }
        //Foreign key for Manufacturer
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
