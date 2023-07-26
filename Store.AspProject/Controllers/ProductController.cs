using Microsoft.AspNetCore.Mvc;

namespace Store.AspProject.Controllers
{
    public class ProductController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        
        [Route("/Product/shopingCart/{ProductId}")]
        public IActionResult AddToCart(int ProductId)
        {


            return View();
        }
        [Route("/Product/Detail/{ProductId}")]
        public IActionResult Details()
        {
            return View();
        }
    }
}
