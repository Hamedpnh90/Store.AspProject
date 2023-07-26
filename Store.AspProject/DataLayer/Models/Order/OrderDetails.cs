using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.AspProject.DataLayer.Models.Order
{
    public class OrderDetails
    {
        [Key]
        public int DetailsId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int Price { get; set; }

        public bool IsDeleted { get; set; } = false;

        [ForeignKey("OrderId")]
        public Order order { get; set; }

        [ForeignKey("ProductId")]
        public Product.Product product { get; set; }
    }
}
