using Microsoft.AspNetCore.Identity;
using Store.AspProject.DataLayer.Models.User;
using Store.AspProject.DataLayer.UserViewModel;

namespace Store.AspProject.Services.Interfces
{
    public interface IUserService
    {

        IList<User> GetAllUsers();

        User GetUserById(int id);


        bool EditUserByAdmin(int id,EditUserViewModel editUser);


        bool EditeUser(User user);

        bool DeleteUser(int id);


        User FindUserByEmail(string Email);

        bool IsPassWordMatched(string Password,string email);

        Task<IdentityResult> RegisterUser(UserRegisterViewModel userRegister);

        Task<SignInResult> Login(UserLoginViewModel userLogin);

        void LogOut();
  

        bool IsUserExist(string Email);

        bool IsUserNameExist(string UserName);  
    }
}
