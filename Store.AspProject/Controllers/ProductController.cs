using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.AspProject.Services.Interfces;
using System.Security.Claims;
using ZarinpalRestApi.Models;
using ZarinpalRestApi.ZarinPack;

namespace Store.AspProject.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public ProductController(IOrderService orderService, IUserService userService, IProductService productService)
        {
            _orderService = orderService;
            _userService = userService;
            _productService = productService;
        }
        public IActionResult Index()
        {
            var user = _userService.GetUserById(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return View(_orderService.GetAllOrder(user.User_ID));
        }

        [Route("/Product/shopingCart/{ProductId}")]
        public IActionResult AddToCart(int ProductId)
        {
            int userid = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            
            var resualt = _orderService.AddOrder(userid, ProductId);

            return RedirectToAction("index");
        }
        [Route("/Product/Detail/{ProductId}")]
        public IActionResult Details(int ProductId)
        {

            return View(_productService.GetProductById(ProductId));
        }
        [Route("/Product/ShowOrderDetail/{OrderId}")]
        public IActionResult ShowOrderDetail(int OrderId)
        {
            
             var orderDetail= _orderService.ShowOrderDetail(OrderId);
            return View(orderDetail);
        }

        [Route("/Product/DeleteOrderDetail/{OrderDetailId}")]
        public IActionResult DeleteOrderDetail(int OrderDetailId)
        {
           var res= _orderService.DeleteOrderDetail(OrderDetailId);
            int userid = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
           var order=_orderService.UnpaidOrder(userid); 
            if (!_orderService.CheckOrderHasvalue(userid))
            {
                _orderService.UpdateOrdersum(order.OrderId);
                return RedirectToAction("index");   
            }

            _orderService.DeleteOrder(userid);

            return RedirectToAction("index");   
        }

        [Route("/Product/Paymentrequest/{orderId}")]
        public IActionResult Paymentrequest(int orderId)
        {
            int userid = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var order = _orderService.UnpaidOrder(userid);

            String MerchantID = "c7ac16b3-a161-435f-ac0d-4e308c60d95c";
            long Amount = order.orderSum;
            String Description = "شارژ حساب";
            var request = new ZarinpalModelV4.Payment.Request
            {
                Amount = Amount,
                CallbackUrl = $"{ Request.Scheme }://{Request.Host}/OnlinePayment/{order.OrderId}",
                Description = Description,
                MerchantId = MerchantID
                
            };
            var response = RestApiVer4.PaymentRequest(request);

            if (response.Data.Code == 100)
            {
                var gatewayLink = RestApiVer4.GenerateGatewayLink(response.Data.Authority);
                return Redirect(gatewayLink);
            }

            ViewBag.Message = response.Data.Code;
            return View("Successfull");
        }
    }
}
