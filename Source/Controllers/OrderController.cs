using Microsoft.AspNetCore.Mvc;
using ProductManager.Service;
using ProductManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace ProductManager.Controllers
{
    public class OrderController : Controller
    {
       private readonly IOrderService _orderService;

        public OrderController(IOrderService Orderservice)
        {
           _orderService = Orderservice;
        }
        public IActionResult Index(string typeGenre, string searchString, string optionsGenre)
        {
            var optionList = new List<string>();
            optionList.Add("Theo tên");
            optionList.Add("Theo loại");

            var genreQuery = _orderService.GetQueryType().Distinct();
            var orderViewModel = new OrderViewModel();
            var orderView = _orderService.GetOrders();
            orderViewModel.Orders = orderView;

            if (!String.IsNullOrEmpty(searchString))
            {
                orderView = _orderService.SearchOrder(searchString);
                orderViewModel.Orders = orderView;
            }

            if (!string.IsNullOrEmpty(typeGenre))
            {
                orderView = _orderService.GetOrderByType(typeGenre);
                orderViewModel.Orders = orderView;
                
            }
            if (!string.IsNullOrEmpty(optionsGenre))
            {
                orderView = _orderService.GetOrderByOptions(optionsGenre);
                orderViewModel.Orders = orderView;

            }


            /*var orderViewModel = new OrderViewModel
            {
                Orders = orderView,
                OrderTypes = new SelectList(genreQuery)
            };*/

            orderViewModel.OrderTypes = new SelectList(genreQuery);
            orderViewModel.Options = new SelectList(optionList);
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