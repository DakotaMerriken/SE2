using dahkm_MDB.API.Domain.Models.Entities;
using dahkm_MDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.API.Domain.Models.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(ICustomerRepository customerRepo, IUnitOfWork unitOfWork)
        {
            _customerRepo = customerRepo;
            _unitOfWork = unitOfWork; 
        }
        public void DeleteCustomer(int id)
        {
            _customerRepo.DeleteCustomer(id);
            _unitOfWork.SaveChanges(); 
        }

        public Customer GetCustomer(int id)
        {
            return _customerRepo.GetCustomer(id); 
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepo.GetCustomers(); 
        }

        public void SaveCustomer(Customer customer)
        {
            _customerRepo.SaveCustomer(customer);
            _unitOfWork.SaveChanges(); 
        }

        public void UpdateCustomer(int id)
        {
            _customerRepo.UpdateCustomer(id);
            _unitOfWork.SaveChanges(); 
        }
    }
}
