using System.ComponentModel.DataAnnotations;

namespace Store.AspProject.DataLayer.Models.UserM
{
    public class UserEmail
    {
        [Key]
        public int EmailId { get; set; }

        [Required]
        public string?  Email { get; set; }

        public bool IsDeleted { get; set; }
    }
}
