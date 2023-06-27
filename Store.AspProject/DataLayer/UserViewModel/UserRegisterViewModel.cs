using System.ComponentModel.DataAnnotations;

namespace Store.AspProject.DataLayer.UserViewModel
{
    public class UserRegisterViewModel
    {
        [Display(Name = "نام کاربری")]
        public string? UserName { get; set; }
        [Display(Name = " ایمیل")]
        [DataType(DataType.EmailAddress)]
        public string? UserEmail { get; set; }

        [Display(Name = " موبایل")]
       
        public string? mobile { get; set; }
        [Display(Name = " رمز عبور")]
        [DataType(DataType.Password)]
        public string? PassWord { get; set; }

        [Display(Name = " تکرار رمز عبور")]
        [Compare("PassWord")]
        [DataType(DataType.Password)]
        public string? Repassword { get; set; }
    }

    public enum RegisterResualt
    {
        success,
        Notsucced
    }
}
