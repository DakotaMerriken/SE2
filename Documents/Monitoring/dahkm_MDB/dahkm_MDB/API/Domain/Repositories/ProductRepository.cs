using dahkm_MDB.API.Domain.Models.Entities;
using dahkm_MDB.API.Domain.Models.Services;
using dahkm_MDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.API.Domain.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(DahkmDbContext context) : base(context)
        {
        }

        public void DeleteProduct(int id)
        {
            Product product = _context.Find<Product>(id);
            _context.Remove(product);
        }

        public Product GetProduct(int id)
        {
            return _context.Find<Product>(id); 
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList<Product>();
        }

        public void SaveProduct(Product product)
        {
            _context.Add(product); 
        }

        public void UpdateProduct(int id)
        {
            Product product = _context.Find<Product>(id);
            _context.Update<Product>(product);
        }
    }
}
