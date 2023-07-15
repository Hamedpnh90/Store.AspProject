using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.AspProject.DataLayer.Context;
using Store.AspProject.DataLayer.Models.Product;
using Store.AspProject.Services.Interfces;

namespace Store.AspProject.Areas.Admin.Controllers

{

    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        AspStoreDbContext _context;

      

        public ProductController(IProductService ProductService, AspStoreDbContext context)
        {
            _productService = ProductService;
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View(_productService.GetAllProduct());
        }

        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.productGroups, "GroupId", "GroupName");
            return View();
        }


        [HttpPost]
        public IActionResult Create(Product product, IFormFile? imgUp)
        {
           if(ModelState.IsValid)
            {
                _productService.AddProduct(product,imgUp);

                return RedirectToAction("Index");   
            }

            ViewData["GroupId"] = new SelectList(_context.productGroups, "GroupId", "GroupName", product.GroupId);
            return View(product);

        }
    }
}
