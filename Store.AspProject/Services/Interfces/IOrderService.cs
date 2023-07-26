using Store.AspProject.DataLayer.Models.Order;
using Store.AspProject.DataLayer.Models.Product;
using Store.AspProject.DataLayer.Models.user;

namespace Store.AspProject.Services.Interfces
{
    public interface IOrderService
    {
        #region Orders
        List<Order> GetAllOrder(string Email);


        int AddOrder(string Email,int ProductId);

        user FindUserByEnail(string Enail);

        Product  FindProductById(int ProductId);

        Order UnpaidOrder( int UserId);

        int UpdateOrdersum(int OrderId);
        OrderDetails OrderDetailsExist(int orderId,int productId);

        bool DeleteOrder(int OrderId);

        bool DeleteOrderDetail(int orderDetail);

        #endregion

    }
}
