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

            

        }

        public async Task<IActionResult> IsAnyUserName(string UserName)
        {
            var res =await _userService.UserNameExisteJson(UserName);

            if(!res)
            {
                return Json(true);  
            }

            else return Json("نام کاربری از قبل ثبت شده است");    
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




            var Res = _userService.Login(login);   


            if(Res.Result.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }

            return View(login);







        }
        #endregion


        #region LogOut


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOut()
        {
           
            _userService.LogOut();

            return Redirect("/Login");
        }
        #endregion
    }
}
