using dahkm_MDB.API.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder(int id);
        void DeleteOrder(int id);
        void UpdateOrder(int id);
        void SaveOrder(Order order);
    }
}
