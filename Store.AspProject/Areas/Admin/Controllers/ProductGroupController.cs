using Microsoft.AspNetCore.Mvc;

namespace Store.AspProject.Areas.Admin.Controllers

{

    [Area("Admin")]
    public class ProductGroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
