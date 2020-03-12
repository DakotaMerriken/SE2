using dahkm_MDB.API.Domain.Models.Entities;
using dahkm_MDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.API.Domain.Models.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _vendorRepo;
        private readonly IUnitOfWork _unitOfWork;
        public VendorService(IVendorRepository vendorRepository, IUnitOfWork unitOfWork)
        {
            _vendorRepo = vendorRepository;
            _unitOfWork = unitOfWork; 
        }
        public void DeleteVendor(int id)
        {
            _vendorRepo.DeleteVendor(id);
            _unitOfWork.SaveChanges(); 
        }

        public Vendor GetVendor(int id)
        {
            return _vendorRepo.GetVendor(id); 
        }

        public IEnumerable<Vendor> GetVendors()
        {
            return _vendorRepo.GetVendors(); 
        }

        public void SaveVendor(Vendor vendor)
        {
            _vendorRepo.SaveVendor(vendor);
            _unitOfWork.SaveChanges();
        }

        public void UpdateVendor(int id)
        {
            _vendorRepo.UpdateVendor(id);
            _unitOfWork.SaveChanges();
        }
    }
}
