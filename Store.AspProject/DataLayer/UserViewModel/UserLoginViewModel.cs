using System.ComponentModel.DataAnnotations;

namespace Store.AspProject.DataLayer.UserViewModel
{
    public class UserLoginViewModel
    {
        [Display(Name = " ایمیل")]
        [DataType(DataType.EmailAddress)]
        public string? UserEmail { get; set; }

        
        [Display(Name = " رمز عبور")]
        [DataType(DataType.Password)]
        public string? PassWord { get; set; }
    }
}
