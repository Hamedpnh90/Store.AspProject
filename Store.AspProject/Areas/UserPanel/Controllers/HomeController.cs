using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.AspProject.Services.Interfces;
using System.Security.Claims;

namespace Store.AspProject.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {


            return View(_userService.GetUserById(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)));
        }
    }
}
