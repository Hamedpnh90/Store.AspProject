
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Store.AspProject.DataLayer.Models.User;
using Store.AspProject.DataLayer.UserViewModel;
using Store.AspProject.Services.Interfces;
using Store.AspProject.Utilites;
using System.Security.Claims;
using System.Text;
using static Store.AspProject.Utilites.FixEmail;

namespace Store.AspProject.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService;
        IViewRenderService _viewRenderService;
        UserManager<IdentityUser> _userManager;
        IEmailSenderService _emailSender;
        public AccountController(IUserService userService, UserManager<IdentityUser> userManager, IViewRenderService viewRenderService, IEmailSenderService emailSender)
        {
            _userService = userService;
            _userManager = userManager;
            _viewRenderService = viewRenderService; 
            _emailSender = emailSender; 
        }
        #region Register
        [HttpGet("Register")]
        public IActionResult Register()
        {
            ViewBag.IsSent = false;
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



            var user = await _userManager.FindByNameAsync(userRegister.UserName);
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

            string? CallBackUrl = Url.ActionLink("confirmEmail","Account", new {UserId=user.Id, token = token , },Request.Scheme); 
         

            string body = await _viewRenderService.RenderToStringAsync("_RegisterEmail", CallBackUrl); 

           await  _emailSender.SendEmail(user.Email,"تایید ایمیل",body);
            ViewBag.IsSent = true;

            return View();
        }


        public async Task<IActionResult> confirmEmail(string UserId, string token)
        {
            if (UserId == null || token == null) return BadRequest();

            var user=await _userManager.FindByIdAsync(UserId);
            if(user == null) return NotFound();       

             token= WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

          var res=  await _userManager.ConfirmEmailAsync(user, token);

            ViewBag.IsConfirmed=res.Succeeded? true:false;
            return View();

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
