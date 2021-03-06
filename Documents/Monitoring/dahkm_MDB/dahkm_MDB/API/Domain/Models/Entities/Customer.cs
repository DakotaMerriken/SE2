﻿using dahkm_MDB.API.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.API.Domain.Models.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public double BalanceDue { get; set; }
        public int CityId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
