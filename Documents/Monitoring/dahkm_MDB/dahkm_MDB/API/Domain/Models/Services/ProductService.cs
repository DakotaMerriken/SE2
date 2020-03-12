using dahkm_MDB.API.Domain.Models.Entities;
using dahkm_MDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.API.Domain.Models.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepo, IUnitOfWork unitOfWork)
        {
            _productRepo = productRepo;
            _unitOfWork = unitOfWork; 
        }
        public void DeleteProduct(int id)
        {
            _productRepo.DeleteProduct(id);
            _unitOfWork.SaveChanges(); 
        }

        public Product GetProduct(int id)
        {
            return _productRepo.GetProduct(id); 
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepo.GetProducts(); 
        }

        public void SaveProduct(Product product)
        {
            _productRepo.SaveProduct(product);
            _unitOfWork.SaveChanges();
        }

        public void UpdateProduct(int id)
        {
            _productRepo.UpdateProduct(id);
            _unitOfWork.SaveChanges();
        }
    }
}
