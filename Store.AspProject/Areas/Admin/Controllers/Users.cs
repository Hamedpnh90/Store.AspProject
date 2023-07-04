﻿using Microsoft.AspNetCore.Mvc;
using Store.AspProject.DataLayer.Models.User;
using Store.AspProject.DataLayer.UserViewModel;
using Store.AspProject.Services.Interfces;

namespace Store.AspProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Users : Controller
    {
       
        IUserService _UserService;

        public Users(IUserService UserService)
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
    }
}
