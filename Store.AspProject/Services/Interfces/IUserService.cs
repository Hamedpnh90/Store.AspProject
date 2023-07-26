using Store.AspProject.DataLayer.Models.user;

using Store.AspProject.DataLayer.UserViewModel;

namespace Store.AspProject.Services.Interfces
{
    public interface IUserService
    {

        IList<user> GetAllUsers();

        user GetUserById(int id);


        bool EditUserByAdmin(int id,EditUserViewModel editUser);


        bool EditeUser(user user);

        bool DeleteUser(int id);


        user FindUserByEmail(string Email);

        bool IsPassWordMatched(string Password,string email);

        user RegisterUser(UserRegisterViewModel userRegister);

        user Login(UserLoginViewModel userLogin);
  

        bool IsUserExist(string Email);

        bool IsUserNameExist(string UserName);  
    }
}
