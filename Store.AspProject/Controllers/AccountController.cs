using Microsoft.AspNetCore.Mvc;
using Store.AspProject.DataLayer.Models.User;
using Store.AspProject.DataLayer.UserViewModel;
using Store.AspProject.Services.Interfces;

namespace Store.AspProject.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService; 
        }
        #region Register
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public IActionResult Register(UserRegisterViewModel userRegister)
        {
            if(!ModelState.IsValid) return View();

            User user = _userService.RegisterUser(userRegister);

            if(user != null)
            {
                ViewBag.User = user;
                return View("RegisterSucceed", user);
            }
            else
            {
                ViewBag.User = user;
                return View(userRegister);
            }
           
           
        }
        #endregion


        #region Login
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public IActionResult Login(UserLoginViewModel login)
        {

            if(!ModelState.IsValid) return View(login);
           
              var res=  _userService.Login(login);

            switch (res)
            {
                case UserLoginResualt.success:
                    ViewBag.res=res;    
                    return Redirect("/");
                    break;
                case UserLoginResualt.WrongPass:
                    ViewBag.res = res;
                    return View(login);
              
            }
            return View();
        }
        #endregion
    }
}
