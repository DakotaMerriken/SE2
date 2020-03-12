using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dahkm_MDB.API.Domain.Models.Entities;
using dahkm_MDB.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dahkm_MDB.API.Controllers
{
    [Route("api/VendorController")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService; 
        }
        // GET: api/Vendor
        [HttpGet]
        public IEnumerable<Vendor> Get()
        {
            return _vendorService.GetVendors(); 
        }

        // GET: api/Vendor/5
        [HttpGet("{id}")]
        public Vendor Get(int id)
        {
            return _vendorService.GetVendor(id); 
        }

        // POST: api/Vendor
        [HttpPost]
        public ActionResult<Vendor> Post(Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            var newVendor = new Vendor();
            newVendor.City = vendor.City;
            newVendor.Name = vendor.Name;
            newVendor.PhoneNumber = vendor.PhoneNumber;
            newVendor.Products = vendor.Products;
            newVendor.StreetAddress = vendor.StreetAddress;
            newVendor.ZipCode = vendor.ZipCode; 

            _vendorService.SaveVendor(newVendor);
            return Ok();
        }

        // PUT: api/Vendor/5
        [HttpPut("{id}")]
        public ActionResult<Vendor> Put(Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            var existingVendor = _vendorService.GetVendor(vendor.Id);
            if (existingVendor != null)
            {
                existingVendor.City = vendor.City;
                existingVendor.Name = vendor.Name;
                existingVendor.PhoneNumber = vendor.PhoneNumber;
                existingVendor.Products = vendor.Products;
                existingVendor.StreetAddress = vendor.StreetAddress;
                existingVendor.ZipCode = vendor.ZipCode;

                _vendorService.UpdateVendor(existingVendor.Id);
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _vendorService.DeleteVendor(id); 
        }
    }
}
