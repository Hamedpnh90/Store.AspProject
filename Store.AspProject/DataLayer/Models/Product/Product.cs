using Store.AspProject.DataLayer.Models.Order;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.AspProject.DataLayer.Models.Product
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "گروه محصول")]
        [Required]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public ProductGroup? ProductGroup { get; set; }


        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string ProductHeadTitle { get; set; }


        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string ProductTitle { get; set; }

        [Display(Name = "توضیح")]
        public string ProductDescription { get; set; }
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public int Price { get; set; }

        [Display(Name = "تصویر")]
        [MaxLength(50)]
        public string? ImageName { get; set; }
        [Display(Name = "تاریخ")]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        [Display(Name = "تگ")]
        [MaxLength(400)]
        public string Tags { get; set; }



        public IList<OrderDetails>? orderDetails { get; set; }
    }
}
