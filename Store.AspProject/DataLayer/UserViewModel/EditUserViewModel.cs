using System.ComponentModel.DataAnnotations;

namespace Store.AspProject.DataLayer.UserViewModel
{
    public class EditUserViewModel
    {

        public string? UserEmail { get; set; }
  
     
        
        public string? UserMobile { get; set; }


        public bool IsAdmin { get; set; }
    }
}
