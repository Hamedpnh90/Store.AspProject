using Microsoft.AspNetCore.Mvc;
using Store.AspProject.Services.Interfces;

namespace Store.AspProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        IUserService _UserService;

        public HomeController(IUserService UserService)
        {
            _UserService = UserService;
        }
      
        public IActionResult Index()
        {
            var user = _UserService.GetAllUsers();
            return View(user);
        }
    }
}
