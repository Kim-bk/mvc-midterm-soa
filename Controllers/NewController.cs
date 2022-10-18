using Microsoft.AspNetCore.Mvc;
using ProductManager.Service;
using ProductManager.Models;

namespace ProductManager.Controllers
{
    public class NewController : Controller
    {
       private readonly INewService _newService;

        public NewController(INewService newService)
        {
           _newService = newService;
        }
        public IActionResult Index(string searchString)
        {
            var newView = _newService.GetNews();
            if (!String.IsNullOrEmpty(searchString))
            {
                newView = _newService.SearchNew(searchString);
            }
            return View(newView);
        }
        public IActionResult Create()
        {
            var typeNews = _newService.GetTypeNew();
            return View(typeNews);
        }
        public IActionResult Save(New news)
        {
            if (news.Id == 0)
            {
                _newService.CreateNew(news);
            }
            else
            {
                _newService.UpdateNew(news);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var news = _newService.GetNewById(id);
            if (news == null) return RedirectToAction("Create");
 
            var typeNews = _newService.GetTypeNew();
            ViewBag.New = news;
            return View(typeNews);
        }
        public IActionResult Delete(int id)
        {
            _newService.DeleteNew(id);
            return RedirectToAction("Index");
        }
    }
}