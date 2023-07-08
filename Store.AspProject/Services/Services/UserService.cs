﻿using Microsoft.AspNetCore.Identity;
using Store.AspProject.DataLayer.Context;
using Store.AspProject.DataLayer.Models.User;
using Store.AspProject.DataLayer.UserViewModel;
using Store.AspProject.Services.Interfces;
using Store.AspProject.Utilites;
using static Store.AspProject.Utilites.FixEmail;

namespace Store.AspProject.Services.Services
{
    public class UserService : IUserService
    {
        IRepository<User> UserRepository;
        AspStoreDbContext _context;

        UserManager<IdentityUser> _userManager;
        public UserService(AspStoreDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public bool DeleteUser(int id)
        {
            User user = _context.users.Find(id);

            if (user == null) return false;

            user.IsDeleted = true;


            return EditeUser(user);


        }

        public bool EditeUser(User user)
        {
            if (user == null) return false;

            _context.users.Update(user);
            _context.SaveChanges();
            return true;
        }

        public IList<User> GetAllUsers()
        {
            return _context.users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.users.FirstOrDefault(u => u.User_ID == id);
        }

        public bool EditUserByAdmin(int id, EditUserViewModel editUser)
        {
            var user = GetUserById(id);

            if (user == null) return false;

            user.IsAdmin = editUser.IsAdmin;
            user.UserMobile = editUser.UserMobile;
            user.UserEmail = editUser.UserEmail;

            _context.users.Update(user);
            _context.SaveChanges();
            return true;
        }

        #region Register
        public async Task<IdentityResult> RegisterUser(UserRegisterViewModel userRegister)
        {


           var res=await  _userManager.CreateAsync(new IdentityUser()
            {
                UserName = userRegister.UserName,
                Email = userRegister.UserEmail,
                PhoneNumber = userRegister.mobile
            }, userRegister.PassWord);

            return res; 
        }

        public bool IsUserExist(string Email)
        {
            var email = Email.ToLower();
            var res = _context.users.Any(u => u.UserEmail == FixEmails.FixEmail(email));
            return res;
        }

        public bool IsUserNameExist(string UserName)
        {
            var username = UserName.ToLower();
            var res = _context.users.Any(u => u.UserName.ToLower() == username);

            return res;
        }
        #endregion


        #region Login

        public User Login(UserLoginViewModel userLogin)
        {
            var HasHPass = PasswordHelper.EncodePasswordMd5(userLogin.PassWord);
            var UserEmail = FixEmails.FixEmail(userLogin.UserEmail);

            var res = IsPassWordMatched(HasHPass, UserEmail);

            if (res)
            {
                return FindUserByEmail(UserEmail);
            }

            return null;

        }

        public User FindUserByEmail(string Email)
        {
            return _context.users.FirstOrDefault(u => u.UserEmail == Email);
        }

        public bool IsPassWordMatched(string Password, string email)
        {
            var user = FindUserByEmail(email);

            if (user != null)
            {
                if (user.PassWord == Password)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            return false;


        }





        #endregion
    }
}
