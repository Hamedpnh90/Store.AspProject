using Store.AspProject.DataLayer.Context;
using Store.AspProject.DataLayer.Models.User;
using Store.AspProject.DataLayer.UserViewModel;
using Store.AspProject.Services.Interfces;

namespace Store.AspProject.Services.Services
{
    public class UserService : IUserService
    {
        IRepository<User> UserRepository;
        AspStoreDbContext _context;

        public UserService(AspStoreDbContext context)
        {
            _context = context;
        }
        public bool DeleteUser(int id)
        {
            User user = _context.users.Find(id);

            if (user == null) return false;

            _context.users.Remove(user);
            _context.SaveChanges();
            return true;
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



        #region Register
        public User RegisterUser(UserRegisterViewModel userRegister)
        {
            if (!IsUserExist(userRegister.UserEmail) && !IsUserNameExist(userRegister.UserName))
            {
                User user = new User()
                {
                    UserName = userRegister.UserName,
                    UserEmail = userRegister.UserEmail,
                    CreatedDate = DateTime.Now,
                    IsAdmin = false,
                    IsDeleted = false,
                    PassWord = userRegister.PassWord,
                    UserMobile = userRegister.mobile

                };

                _context.users.Add(user);
                _context.SaveChanges();
              return  user;
            }

          else
            {
                return null;
            }
        }
        public bool IsUserExist(string Email)
        {
           var email=Email.ToLower();
            var res= _context.users.Any(u=>u.UserEmail == email);
            return res;
        }

        public bool IsUserNameExist(string UserName)
        {
            var username = UserName.ToLower();
            var res= _context.users.Any(u => u.UserName.ToLower() == username);

            return res;
        }
        #endregion
    }
}
