using dahkm_MDB.API.Domain.Models.Entities;
using dahkm_MDB.API.Domain.Models.Services;
using dahkm_MDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.API.Domain.Repositories
{
    public class CustomerRepository : BaseRepository,  ICustomerRepository
    {
        public CustomerRepository(DahkmDbContext context) : base(context)
        {
        }

        public void DeleteCustomer(int id)
        {
            Customer customer = _context.Find<Customer>(id);
            _context.Remove(customer);
        }

        public Customer GetCustomer(int id)
        {
            return _context.Find<Customer>(id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList<Customer>();
        }

        public void SaveCustomer(Customer customer)
        {
            _context.Add(customer);
        }

        public void UpdateCustomer(int id)
        {
            Customer customer = _context.Find<Customer>(id);
            _context.Update<Customer>(customer);
        }
    }
}
