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
    [Route("api/OrderController")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService; 
        }

        // GET: api/Order
        [HttpGet]
        public IEnumerable<Order> Get()
        {
           return _orderService.GetOrders(); 
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _orderService.GetOrder(id); 
        }

        // POST: api/Order
        [HttpPost]
        public ActionResult<Order> Post([FromBody]Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            var newOrder = new Order();
            newOrder.CustomerId = order.CustomerId;
            newOrder.OrderDate = order.OrderDate;
            newOrder.AmountDue = order.AmountDue;
            newOrder.Product = order.Product;
            newOrder.ProductId = order.ProductId;
            newOrder.Quantity = order.Quantity;
            newOrder.RecieveDate = order.RecieveDate;
            newOrder.ShippingCost = order.ShippingCost;
            newOrder.Discount = order.Discount;


            _orderService.SaveOrder(newOrder);
            return Ok();
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public ActionResult<Order> Put([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            var existingOrder = _orderService.GetOrder(order.Id);
            if (existingOrder != null)
            {
                existingOrder.CustomerId = order.CustomerId;
                existingOrder.OrderDate = order.OrderDate; 
                existingOrder.AmountDue = order.AmountDue;
                existingOrder.Product = order.Product;
                existingOrder.ProductId = order.ProductId;
                existingOrder.Quantity = order.Quantity;
                existingOrder.RecieveDate = order.RecieveDate;
                existingOrder.ShippingCost = order.ShippingCost;
                existingOrder.Discount = order.Discount; 



                _orderService.UpdateOrder(existingOrder.Id);
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
            _orderService.DeleteOrder(id); 
        }
    }
}
