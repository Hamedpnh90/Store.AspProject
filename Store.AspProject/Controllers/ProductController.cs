using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.AspProject.Services.Interfces;
using System.Security.Claims;

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

    }
}
