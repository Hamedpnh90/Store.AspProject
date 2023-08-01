using Microsoft.AspNetCore.Mvc;
using Store.AspProject.Services.Interfces;
using System.Diagnostics;

namespace Store.AspProject.Controllers
{
    public class HomeController : AdminbaseController
    {
        private readonly IProductService _productService;
        IUserService _userService;
        public HomeController(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService; 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string Title)
        {
            
            return View(_productService.GetProductBySearch(Title));
        }

        public IActionResult Submitemail(string Emailval)
        {
            

            if(Emailval!=null)
            {
                     _userService.AddEmail(Emailval);
               
                    return new JsonResult(new { status = "success" });
               
               
            }

        

            return new JsonResult(new { status = "Error" });
            

        }


        public IActionResult abouUs()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}