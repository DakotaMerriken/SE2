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
    [Route("api/ProductController")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;    
        }
        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetProducts(); 
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productService.GetProduct(id); 
        }

        // POST: api/Product
        [HttpPost]
        public ActionResult<Product> Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            var newProduct = new Product();
            newProduct.Manufacturer = product.Manufacturer;
            newProduct.ManufacturerId = product.ManufacturerId;
            newProduct.ModelNumber = product.ModelNumber;
            newProduct.Name = product.Name;
            newProduct.Orders = product.Orders;
            newProduct.PricePerUnit = product.PricePerUnit;
            newProduct.Type = product.Type; 

            _productService.SaveProduct(newProduct);
            return Ok();
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public ActionResult<Product> Put(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            var existingProduct = _productService.GetProduct(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Manufacturer = product.Manufacturer;
                existingProduct.ManufacturerId = product.ManufacturerId;
                existingProduct.ModelNumber = product.ModelNumber;
                existingProduct.Name = product.Name;
                existingProduct.Orders = product.Orders;
                existingProduct.PricePerUnit = product.PricePerUnit;
                existingProduct.Type = product.Type;

                _productService.UpdateProduct(existingProduct.Id);
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
            _productService.DeleteProduct(id); 
        }
    }
}
