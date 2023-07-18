using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Store.AspProject.DataLayer.Models.User;
using Store.AspProject.DataLayer.UserViewModel;
using Store.AspProject.Services.Interfces;
using System.Security.Claims;
using static Store.AspProject.Utilites.FixEmail;

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
            if (!ModelState.IsValid) return View();

            User user = _userService.RegisterUser(userRegister);

            if (user != null)
            {
                ViewBag.UserExist = true;
                ViewBag.User = user;
                return View("RegisterSucceed", user);
            }
            else
            {
                ViewBag.UserExist = false;
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

            if (!ModelState.IsValid) return View(login);




            var user = _userService.Login(login);
            //login

            if (user != null)
            {
                var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.User_ID.ToString()),
                        new Claim("IsAdmin",user.IsAdmin.ToString())
                    };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var Principal = new ClaimsPrincipal(identity);

                var propertise = new AuthenticationProperties()
                {
                    IsPersistent = login.RememberMe
                };

                HttpContext.SignInAsync(Principal, propertise);

                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError("UserEmail", "ایمیل شما فعال سازی نشده است ");
                
                return View(login);
            }




            return View();
        }
        #endregion


        #region LogOut

        [Route("LogOut")]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/Login");
        }
        #endregion
    }
}
