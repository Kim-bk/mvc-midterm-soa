using Microsoft.AspNetCore.Mvc;
using ProductManager.Service;
using ProductManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductManager.Controllers
{
    public class OrderController : Controller
    {
       private readonly IOrderService _orderService;

        public OrderController(IOrderService Orderservice)
        {
           _orderService = Orderservice;
        }
        public IActionResult Index(string typeGenre, string searchString)
        {
            // Use LINQ to get list of TypeOrder.
            var genreQuery = _orderService.GetQueryType();

            var orderView = _orderService.GetOrders();
            var typeOrders = _orderService.GetTypeOrder();
            if (!String.IsNullOrEmpty(searchString))
            {
                orderView = _orderService.SearchOrder(searchString);
            }

            if (!string.IsNullOrEmpty(typeGenre))
            {
                orderView = _orderService.GetOrderByType(typeGenre);
            }

            var orderViewModel = new OrderViewModel
            {
                Orders = orderView,
                OrderTypes = new SelectList(genreQuery)
            };
            return View(orderViewModel);
        }
        public IActionResult Create()
        {
            var typeOrders = _orderService.GetTypeOrder();
            return View(typeOrders);
        }
        public IActionResult Save(Order Orders)
        {
            if (Orders.Id == 0)
            {
                _orderService.CreateOrder(Orders);
            }
            else
            {
                _orderService.UpdateOrder(Orders);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var Orders = _orderService.GetOrderById(id);
            if (Orders == null) return RedirectToAction("Create");
 
            var typeOrders = _orderService.GetTypeOrder();
            ViewBag.Order = Orders;
            return View(typeOrders);
        }
        public IActionResult Delete(int id)
        {
            _orderService.DeleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}