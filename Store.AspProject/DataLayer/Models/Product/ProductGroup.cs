using System.ComponentModel.DataAnnotations;

namespace Store.AspProject.DataLayer.Models.Product
{
    public class ProductGroup
    {
        [Key]
        public int GroupId { get; set; }
        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string GroupName { get; set; }

        public List<Product> Products { get; set; }
    }
}
