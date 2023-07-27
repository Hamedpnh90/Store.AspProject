using Store.AspProject.DataLayer.Models.Order;
using Store.AspProject.DataLayer.Models.Product;
using Store.AspProject.DataLayer.Models.user;

namespace Store.AspProject.Services.Interfces
{
    public interface IOrderService
    {
        #region Orders
        List<Order> GetAllOrder(int UserId);


        int AddOrder(int UserId, int ProductId);

        user FindUserByID(int UserId);

        Product  FindProductById(int ProductId);

        Order UnpaidOrder( int UserId);

        int UpdateOrdersum(int OrderId);
        OrderDetails OrderDetailsExist(int orderId,int productId);

        bool DeleteOrder(int OrderId);

        bool DeleteOrderDetail(int orderDetail);


        List<OrderDetails> ShowOrderDetail(int OrderId);

        #endregion

    }
}
