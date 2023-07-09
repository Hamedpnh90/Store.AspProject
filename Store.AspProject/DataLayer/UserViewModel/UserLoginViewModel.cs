using System.ComponentModel.DataAnnotations;

namespace Store.AspProject.DataLayer.UserViewModel
{
    public class UserLoginViewModel
    {
        [Display(Name = " نام کاربری")]
        
        public string? UserName { get; set; }

        
        [Display(Name = " رمز عبور")]
        [DataType(DataType.Password)]
        public string? PassWord { get; set; }
        public bool  RememberMe { get; set; }

        
    
      
    }

    public enum UserLoginResualt
    {
        success,
        WrongPass
       
    }
}
