using dahkm_MDB.API.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.Interfaces
{
    public interface IVendorRepository
    {
        IEnumerable<Vendor> GetVendors();
        Vendor GetVendor(int id);
        void DeleteVendor(int id);
        void UpdateVendor(int id);
        void SaveVendor(Vendor vendor);
    }
}
