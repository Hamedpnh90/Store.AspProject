using Microsoft.AspNetCore.Mvc;
using Store.AspProject.Services.Interfces;
using System.Diagnostics;

namespace Store.AspProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string Title)
        {
            
            return View(_productService.GetProductBySearch(Title));
        }


        


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}