using Store.AspProject.DataLayer.Models.User;

namespace Store.AspProject.Services.Interfces
{
    public interface IUserService
    {

        IList<User> GetAllUsers();

        User GetUserById(int id);

        bool EditeUser(User user);

        bool DeleteUser(int id);    
    }
}
