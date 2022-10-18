using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManager.Models;
using ProductManager.Service;

namespace ProductManager.Service
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private static Random random = new Random();
        public OrderService(DataContext context)
        {
            _context = context;
        }
        public List<Order> GetOrderByType(string typeOrder)
        {
            return _context.Orders.Where(n => n.OrderType!.OrderTypeName!.Equals(typeOrder)).ToList();
        }
        public List<Order> SearchOrder(string searchingString)
        {
            return _context.Orders.Where(s => s.Name!.Contains(searchingString) 
                                    || s.CustomerEmail!.Contains(searchingString)
                                    || s.OrderCode!.Contains(searchingString)).ToList();
        }
        public void CreateOrder(Order Order)
        {
            var existedOrder = _context.Orders.FirstOrDefault(n => n.OrderCode!.Equals(Order.OrderCode));
            if (existedOrder != null)
            {
                throw new ArgumentException("Order Code is duplicated !");
            }

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Order.OrderCode = new string((Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray()));
            Order.CreatedDate = DateTime.Now;
            _context.Orders.Add(Order);
            _context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
           var existedOrder = GetOrderById(id);
           if (existedOrder == null) return;

           _context.Orders.Remove(existedOrder);
           _context.SaveChanges();
        }

        public List<OrderType> GetTypeOrder()
        {
            return _context.OrderType.ToList();
        }

        public Order? GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(p=>p.Id==id);
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.Include(p=>p.OrderType).ToList();
        }

        public void UpdateOrder(Order Orders)
        {
            var existedOrder = GetOrderById(Orders.Id);
            if (existedOrder == null) return;
            existedOrder.Name = Orders.Name;
            existedOrder.OrderCode = Orders.OrderCode;

            var checkDuplicated = _context.Orders.FirstOrDefault(n => n.OrderCode!.Equals(Orders.OrderCode));
            if (checkDuplicated != null)
            {
                throw new ArgumentException("Slug is duplicated !");
            }

            existedOrder.CustomerEmail = Orders.CustomerEmail;
            existedOrder.CreatedDate = DateTime.Now;
            existedOrder.Image = Orders.Image;
            existedOrder.OrderTypeId = Orders.OrderTypeId;
            _context.Orders.Update(existedOrder);
            _context.SaveChanges();
        }

        public IQueryable<string> GetQueryType()
        {
            return  from m in _context.Orders
                    orderby m.OrderType!.OrderTypeName
                    select m.OrderType!.OrderTypeName;
        }

        public List<Order> GetOrderByOptions(string option)
        {
            if (option.Equals("Theo tên"))
            {
                return _context.Orders.OrderByDescending(n => n.Name).ToList();
            }    

            else 
            {
                return _context.Orders.OrderByDescending(n => n.OrderType!.OrderTypeName).ToList();
            }    
        }
    }
}