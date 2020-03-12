using dahkm_MDB.API.Domain.Models.Entities;
using dahkm_MDB.API.Domain.Models.Services;
using dahkm_MDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.API.Domain.Repositories
{
    public class VendorRepository : BaseRepository, IVendorRepository
    {
        public VendorRepository(DahkmDbContext context) : base(context)
        {
        }

        public void DeleteVendor(int id)
        {
            Vendor vendor = _context.Find<Vendor>(id);
            _context.Remove(vendor);
        }

        public Vendor GetVendor(int id)
        {
            return _context.Find<Vendor>(id); 
        }

        public IEnumerable<Vendor> GetVendors()
        {
            return _context.Vendors.ToList<Vendor>();
        }

        public void SaveVendor(Vendor vendor)
        {
            _context.Add(vendor); 
        }

        public void UpdateVendor(int id)
        {
            Vendor vendor = _context.Find<Vendor>(id);
            _context.Update<Vendor>(vendor);
        }
    }
}
