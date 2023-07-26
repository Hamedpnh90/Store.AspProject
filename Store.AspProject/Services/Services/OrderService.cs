﻿using Store.AspProject.DataLayer.Context;
using Store.AspProject.DataLayer.Models.Order;
using Store.AspProject.DataLayer.Models.Product;
using Store.AspProject.DataLayer.Models.user;
using Store.AspProject.Services.Interfces;

namespace Store.AspProject.Services.Services
{
    public class OrderService : IOrderService
    {
        AspStoreDbContext _context;

        public OrderService(AspStoreDbContext context)
        {
            _context = context;
        }

        public int AddOrder(string Email, int ProductId)
        {
            var user=FindUserByEnail(Email);
            var product=FindProductById(ProductId);

           var Order = UnpaidOrder(user.User_ID);

            if(Order == null)
            {
                Order order = new Order()
                {
                    IsFinally = false,
                    orderSum = product.Price,
                    orderDetails = new List<OrderDetails>()
                    
                    {
                        
                       new OrderDetails()
                       {
                           ProductId=product.ProductId,
                           Count=1,
                           Price=product.Price
                       }
                    }
                    

                };

                _context.Add(order);    
                _context.SaveChanges(); 
            }

            else
            {
                var orderDetails = OrderDetailsExist(Order.OrderId, product.ProductId);

                if(orderDetails != null)
                {
                    orderDetails.Count = 1; 
                    _context.Update(orderDetails); 
                }
                else
                {
                    orderDetails = new OrderDetails()
                    {
                        ProductId = product.ProductId,
                        Count = 1,  
                        OrderId=Order.OrderId,
                        Price=product.Price 
                    };

                    _context.OrderDetails.Add(orderDetails);
                }
            }

            _context.SaveChanges();

            int orderSum=UpdateOrdersum(Order.OrderId);
            return Order.OrderId;    

        }

        public bool DeleteOrder(int OrderId)
        {
            var order=_context.Order.Find(OrderId);
            if(order==null) return false;   
            order.IsFinally = true;
            _context.Order.Update(order);
            _context.SaveChanges();
            return true;    
        }

        public bool DeleteOrderDetail(int orderDetail)
        {
            var orderdetail=_context.OrderDetails.Find(orderDetail);    
            if(orderdetail==null) return false;
            _context.OrderDetails.Remove(orderdetail);
            _context.SaveChanges();
            return true;
        }

        public Product FindProductById(int ProductId)
        {
            return _context.products.Find(ProductId);   
        }

        public user FindUserByEnail(string Enail)
        {
            return _context.users.FirstOrDefault(u=>u.UserEmail == Enail);  
        }

        public List<Order> GetAllOrder(string Email)
        {

            var user=FindUserByEnail(Email);
            return _context.Order.Where(o => o.user.User_ID == user.User_ID).ToList();
        }

        public OrderDetails OrderDetailsExist(int orderId, int productId)
        {
            return _context.OrderDetails.FirstOrDefault(o=>o.OrderId==orderId && o.ProductId==productId);   
        }

        public Order UnpaidOrder(int UserId)
        {
            return _context.Order.FirstOrDefault(o=>o.userId==UserId && !o.IsFinally);
        }

        public int UpdateOrdersum(int OrderId)
        {
            var order = _context.Order.Find(OrderId);

            if(order!=null)
            {
                var orderDetail=_context.OrderDetails.Where(o=>o.OrderId==order.OrderId).Sum(o=>o.Price * o.Count);

                order.orderSum = orderDetail;

                _context.Order.Update(order);
                _context.SaveChanges();
                return order.orderSum;
            }
            return order.orderSum;
        }
    }
}
