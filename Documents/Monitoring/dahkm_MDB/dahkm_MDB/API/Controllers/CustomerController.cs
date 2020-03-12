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
    [Route("api/CustomerController")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService; 
        }
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var customers = _customerService.GetCustomers();
            return customers; 
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _customerService.GetCustomer(id); 
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            var newCustomer = new Customer();
            newCustomer.FirstName = customer.FirstName;
            newCustomer.LastName = customer.LastName;
            newCustomer.Orders = customer.Orders;
            newCustomer.PhoneNumber = customer.PhoneNumber;
            newCustomer.Address = customer.Address;
            newCustomer.BalanceDue = customer.BalanceDue;
            newCustomer.CityId = customer.CityId; 
            

            _customerService.SaveCustomer(newCustomer);
            return Ok();
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            var existingCustomer = _customerService.GetCustomer(customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Orders = customer.Orders;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                existingCustomer.CityId = customer.CityId;
                existingCustomer.BalanceDue = customer.BalanceDue;
                existingCustomer.Address = customer.Address; 

                _customerService.UpdateCustomer(existingCustomer.Id);
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
            _customerService.DeleteCustomer(id); 
        }
    }
}
