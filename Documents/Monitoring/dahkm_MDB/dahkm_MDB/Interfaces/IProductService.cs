using dahkm_MDB.API.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        void DeleteProduct(int id);
        void UpdateProduct(int id);
        void SaveProduct(Product product);
    }
}
