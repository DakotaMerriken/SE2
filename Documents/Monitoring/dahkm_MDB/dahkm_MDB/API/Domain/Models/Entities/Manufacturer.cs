using System.Collections.Generic;

namespace dahkm_MDB.API.Domain.Models.Entities
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}