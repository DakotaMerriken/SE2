using dahkm_MDB.API.Domain.Models.Entities;
using dahkm_MDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.API.Domain.Models.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepo, IUnitOfWork unitOfWork)
        {
            _orderRepo = orderRepo;
            _unitOfWork = unitOfWork; 
        }
        public void DeleteOrder(int id)
        {
            _orderRepo.DeleteOrder(id);
            _unitOfWork.SaveChanges();
        }

        public Order GetOrder(int id)
        {
            return _orderRepo.GetOrder(id); 
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderRepo.GetOrders(); 
        }

        public void SaveOrder(Order order)
        {
            _orderRepo.SaveOrder(order);
            _unitOfWork.SaveChanges();
        }

        public void UpdateOrder(int id)
        {
            _orderRepo.UpdateOrder(id);
            _unitOfWork.SaveChanges();
        }
    }
}
