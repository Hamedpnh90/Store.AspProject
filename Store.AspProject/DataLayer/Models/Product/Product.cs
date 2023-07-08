using System.ComponentModel.DataAnnotations;

namespace Store.AspProject.DataLayer.Models.Product
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }

        [Required]
        [Display(Name = "اسم محصول")]
        [MaxLength(100)]
        public string ProductName { get; set; }
        [Display(Name = " توضحیات")]
        [MaxLength(300)]
        public string? Description { get; set; }
        [Required]
        [Display(Name = " قیمت")]
        public int Price { get; set; }
        [Display(Name = " تصویر")]
        [MaxLength(50)]
        public string? ImageName { get; set; }

        [Display(Name = " حذف شده")]
        public bool IsDeleted { get; set; }
    }
}
