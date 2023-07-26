using Microsoft.AspNetCore.Mvc;
using Store.AspProject.DataLayer.Models.user;
using Store.AspProject.DataLayer.UserViewModel;
using Store.AspProject.Services.Interfces;

namespace Store.AspProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
       
        IUserService _UserService;

        public UsersController(IUserService UserService)
        {
            _UserService = UserService; 
        }
        public IActionResult Index()
        {
            var user=_UserService.GetAllUsers();    
            return View(user);
        }

        [HttpGet("Admin/EditUser/{id}")]
        public IActionResult EditUser(int id)
        {
            var user=_UserService.GetUserById(id);
            return View(user);
        }

        [HttpPost("Admin/EditUser/{id}")]
        public IActionResult EditUser(int id, EditUserViewModel editUser)
        {
            _UserService.EditUserByAdmin(id, editUser);
            return Redirect("/Admin");   
        }
        [HttpGet("Admin/Delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user=_UserService.GetUserById(id);  
            return View(user);  
        }

        [HttpPost("Admin/Delete/")]
        public IActionResult DeletUser(user user)
        {
            _UserService.DeleteUser(user.User_ID);


            return Redirect("/admin");
        }
    }
}
