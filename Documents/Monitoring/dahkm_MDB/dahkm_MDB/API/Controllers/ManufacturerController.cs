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
    [Route("api/ManufacturerController")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {

        private readonly IManufacturerService _manufacturerService;
        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService; 
        }
        // GET: api/Manufacturer
        [HttpGet]
        public IEnumerable<Manufacturer> Get()
        {
            return _manufacturerService.GetManufacturers(); 
        }

        // GET: api/Manufacturer/5
        [HttpGet("{id}")]
        public Manufacturer Get(int id)
        {
            return _manufacturerService.GetManufacturer(id); 
        }

        // POST: api/Manufacturer
        [HttpPost]
        public ActionResult<Manufacturer> Post(Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            var newManufacturer = new Manufacturer();
            newManufacturer.City = manufacturer.City;
            newManufacturer.Name = manufacturer.Name;
            newManufacturer.PhoneNumber = manufacturer.PhoneNumber;
            newManufacturer.Products = manufacturer.Products;
            newManufacturer.StreetAddress = manufacturer.StreetAddress;
            newManufacturer.ZipCode = manufacturer.ZipCode; 

            _manufacturerService.SaveManufacturer(newManufacturer);
            return Ok();
        }

        // PUT: api/Manufacturer/5
        [HttpPut("{id}")]
        public ActionResult<Manufacturer> Put(Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            var existingManufacturer = _manufacturerService.GetManufacturer(manufacturer.Id);
            if (existingManufacturer != null)
            {
                existingManufacturer.City = manufacturer.City;
                existingManufacturer.Name = manufacturer.Name;
                existingManufacturer.PhoneNumber = manufacturer.PhoneNumber;
                existingManufacturer.Products = manufacturer.Products;
                existingManufacturer.StreetAddress = manufacturer.StreetAddress;
                existingManufacturer.ZipCode = manufacturer.ZipCode;

                _manufacturerService.UpdateManufacturer(existingManufacturer.Id);
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
            _manufacturerService.DeleteManufacturer(id); 
        }
    }
}
