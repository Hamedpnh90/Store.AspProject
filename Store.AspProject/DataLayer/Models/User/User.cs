using System.ComponentModel.DataAnnotations;

namespace Store.AspProject.DataLayer.Models.User
{
    public class User: BaseEntity
    {
        [Key]
        public int User_ID { get; set; }
        [Required]  
        [MaxLength(255)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(300)]
        public string? UserEmail { get; set; }
        [Required]
        [MaxLength(255)]
        public string? PassWord { get; set; }
        [Required]
        [MaxLength(50)]
        public string? UserMobile { get; set; }

        [Required]
 
        public bool IsAdmin { get; set; }
        public bool Rememberme { get; set; }



    }
}
