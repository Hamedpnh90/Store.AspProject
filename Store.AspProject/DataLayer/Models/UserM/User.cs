using System.ComponentModel.DataAnnotations;

namespace Store.AspProject.DataLayer.Models.user
{
    public class user: BaseEntity
    {
        [Key]
        public int User_ID { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]  
        [MaxLength(255)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        public string? UserEmail { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(255)]
        public string? PassWord { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        public string? UserMobile { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
 
        public bool IsAdmin { get; set; }
        public bool Rememberme { get; set; }


        public IList<Order.Order> orders { get; set; }

    }
}
