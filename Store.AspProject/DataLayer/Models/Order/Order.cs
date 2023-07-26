

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.AspProject.DataLayer.Models.Order
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int userId { get; set; }
        [Required]
        public int orderSum { get; set; }

        public bool IsFinally { get; set; }

        [ForeignKey("userId")]
        public user.user user { get; set; }

        public IList<OrderDetails> orderDetails { get; set; }
    }
}
