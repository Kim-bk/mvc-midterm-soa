using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManager.Models;

namespace ProductManager.Service
{
    public interface IOrderService
    {
        IQueryable<string> GetQueryType();
        List<Order> SearchOrder(string searchingString);
        List<Order> GetOrderByType(string typeOrder);
        List<Order> GetOrders();
        Order? GetOrderById(int id);

        void CreateOrder(Order Order);

        void UpdateOrder(Order Order);

        void DeleteOrder(int id);

        List<OrderType> GetTypeOrder();
    }
}