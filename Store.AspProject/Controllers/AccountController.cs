using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

using Store.AspProject.DataLayer.UserViewModel;
using Store.AspProject.Services.Interfces;
using System.Security.Claims;
using ZarinpalRestApi.Models;
using ZarinpalRestApi.ZarinPack;
using static Store.AspProject.Utilites.FixEmail;

namespace Store.AspProject.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService;
        IOrderService _orderService;
        public AccountController(IUserService userService, IOrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
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

            var user = _userService.RegisterUser(userRegister);

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


        #region OnlinePayment
        [Route("OnlinePayment/{id}")]
        public IActionResult OnlinePayment(int id, string authority, string status)
        {
            int userid = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var order = _orderService.UnpaidOrder(userid);
            String MerchantID = "c7ac16b3-a161-435f-ac0d-4e308c60d95c";


            if (status == "NOK")
            {

                ViewBag.Text = "Transaction unsuccessful.";
            }

            else if (status == "OK")
            {

                var request = new ZarinpalModelV4.Verify.Request
                {
                    MerchantId = MerchantID,
                    Authority = authority,
                    Amount = order.orderSum * 10
                };

                var response = RestApiVer4.Verify(request);

                if (response.Data.Code == 100) // موفقیت امیز
                {
                    ViewBag.IsSuccess = true;
                    ViewBag.code = $"شماره تراکنش: {response.Data.RefId}";


                }
                else if (response.Data.Code == 101) // تکرار تراکنشی که موفقیت امیز بوده
                {
                    ViewBag.IsSuccess = true;
                    ViewBag.code = $"شماره تراکنش: {response.Data.RefId}";
                }
                else // خطا
                {

                    ViewBag.Error = $"Transaction unsuccessful. Status: {response.Data.Code}";
                }
            }

            return View();
        }


        #endregion
    }
}
