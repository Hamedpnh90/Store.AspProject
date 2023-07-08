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
        public async Task<IActionResult> Register(UserRegisterViewModel userRegister)
        {
            if (!ModelState.IsValid) return View(userRegister);

            var Resualt = await _userService.RegisterUser(userRegister);

              if(!Resualt.Succeeded)
            {
                foreach (var item in Resualt.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                    return View();  
                }
            }



            return RedirectToAction("Login");

            #endregion

        }
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

          

                return Redirect("/");
           
           




          
        }
        #endregion


        #region LogOut

        [Route("LogOut")]
        public IActionResult LogOut()
        {
           

            return Redirect("/Login");
        }
        #endregion
    }
}
