using Store.AspProject.DataLayer.Context;
using Store.AspProject.DataLayer.Models.User;
using Store.AspProject.Services.Interfces;

namespace Store.AspProject.Services.Services
{
    public class UserService : IUserService
    {

        AspStoreDbContext _context;

        public UserService(AspStoreDbContext context)
        {
            _context = context;
        }
        public bool DeleteUser(int id)
        {
            User user = _context.users.Find(id);    

            if (user == null)   return false;   

            _context.users.Remove(user);    
            _context.SaveChanges(); 
            return true;
        }

        public bool EditeUser(User user)
        {
            if(user == null) return false;

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
            return _context.users.FirstOrDefault(u=>u.User_ID==id);
        }
    }
}
