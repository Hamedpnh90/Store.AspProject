using Store.AspProject.DataLayer.Models.User;
using Store.AspProject.DataLayer.UserViewModel;

namespace Store.AspProject.Services.Interfces
{
    public interface IUserService
    {

        IList<User> GetAllUsers();

        User GetUserById(int id);

        bool EditeUser(User user);

        bool DeleteUser(int id);


        User RegisterUser(UserRegisterViewModel userRegister);

        bool IsUserExist(string Email);

        bool IsUserNameExist(string UserName);  
    }
}
