using Microsoft.AspNetCore.Mvc;

namespace Store.AspProject.Controllers
{
    public class AccountController : Controller
    {

        #region Register
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }


        #endregion


        #region Login
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }
        #endregion
    }
}
