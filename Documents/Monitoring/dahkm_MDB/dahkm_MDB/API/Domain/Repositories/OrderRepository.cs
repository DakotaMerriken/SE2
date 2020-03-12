using dahkm_MDB.API.Domain.Models.Entities;
using dahkm_MDB.API.Domain.Models.Services;
using dahkm_MDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.API.Domain.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(DahkmDbContext context) : base(context)
        {
            
        }

        public void DeleteOrder(int id)
        {
            Order order = _context.Find<Order>(id);
            _context.Remove(order);
        }

        public Order GetOrder(int id)
        {
            return _context.Find<Order>(id); 
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.ToList<Order>();
        }

        public void SaveOrder(Order order)
        {
            _context.Add(order); 
        }

        public void UpdateOrder(int id)
        {
            Order order = _context.Find<Order>(id);
            _context.Update<Order>(order);
        }
    }
}
