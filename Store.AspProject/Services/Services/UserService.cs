using Store.AspProject.DataLayer.Context;
using Store.AspProject.DataLayer.Models.user;
using Store.AspProject.DataLayer.Models.UserM;
using Store.AspProject.DataLayer.UserViewModel;
using Store.AspProject.Services.Interfces;
using Store.AspProject.Utilites;
using static Store.AspProject.Utilites.FixEmail;

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
            user user = _context.users.Find(id);

            if (user == null) return false;

            user.IsDeleted = true;

            
            return EditeUser(user);

           
        }

        public bool EditeUser(user user)
        {
            if (user == null) return false;

            _context.users.Update(user);
            _context.SaveChanges();
            return true;
        }

        public IList<user> GetAllUsers()
        {
            return _context.users.ToList();
        }

        public user GetUserById(int id)
        {
            return _context.users.FirstOrDefault(u => u.User_ID == id);
        }

        public bool EditUserByAdmin(int id,EditUserViewModel editUser)
        {
            var user = GetUserById(id);

            if(user == null) return false;

            user.IsAdmin = editUser.IsAdmin;    
            user.UserMobile = editUser.UserMobile;  
            user.UserEmail = editUser.UserEmail;

            _context.users.Update(user);
            _context.SaveChanges();
            return true;
        }

        #region Register
        public user RegisterUser(UserRegisterViewModel userRegister)
        {
            if (!IsUserExist(userRegister.UserEmail) && !IsUserNameExist(userRegister.UserName))
            {

                
                user user = new user()
                {
                    user_name = userRegister.UserName,
                    UserEmail = FixEmails.FixEmail(userRegister.UserEmail),
                    CreatedDate = DateTime.Now,
                    IsAdmin = false,
                    IsDeleted = false,
                    PassWord = PasswordHelper.EncodePasswordMd5(userRegister.PassWord) ,
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
            var res = _context.users.Any(u => u.UserEmail == FixEmails.FixEmail(email));
            return res;
        }

        public bool IsUserNameExist(string UserName)
        {
            var username = UserName.ToLower();
            var res= _context.users.Any(u => u.user_name.ToLower() == username);

            return res;
        }
        #endregion


        #region Login

        public user Login(UserLoginViewModel userLogin)
        {
            var HasHPass=PasswordHelper.EncodePasswordMd5(userLogin.PassWord);  
            var UserEmail=FixEmails.FixEmail(userLogin.UserEmail);  

             var res= IsPassWordMatched(HasHPass,UserEmail);  

            if(res)
            {
               return FindUserByEmail(UserEmail);
            }

            return null;

        }

        public user FindUserByEmail(string Email)
        {
            return _context.users.FirstOrDefault(u=>u.UserEmail == Email);  
        }

        public bool IsPassWordMatched(string Password, string email)
        {
            var user=FindUserByEmail(email);

            if (user!=null)
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

        public bool AddEmail(string Email)
        {
            if(Email==null) return false;
            _context.UserEmails.Add(new UserEmail()
            {
                Email = Email,
                IsDeleted=false
            }); 
            _context.SaveChanges(); 
            return true;    
        }





        #endregion
    }
}
