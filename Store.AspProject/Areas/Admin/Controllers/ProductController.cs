using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.AspProject.DataLayer.Context;
using Store.AspProject.DataLayer.Models.Product;
using Store.AspProject.Services.Interfces;
using Store.AspProject.Utilites;

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
        
        public IActionResult Index(bool res=false)
        {
            ViewBag.res = res;
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


        
        public IActionResult EditProduct(int id)
        {

           var produvt= _productService.GetProductById(id);  

            if(produvt == null) return NotFound();

            ViewData["GroupId"] = new SelectList(_context.productGroups, "GroupId", "GroupName", produvt.GroupId);
            return View(produvt);


            
        }

        [HttpPost]
        public IActionResult EditProduct(int id, Product product, IFormFile? imgUp)
        {

          if(id!=product.ProductId) return BadRequest();

          var res= _productService.EditProduct(id,product,imgUp);        

            if(res!=null) return RedirectToAction("Index");

            return View(product);
        
       }


        public IActionResult Delete(int id)
        {

          var res=  _productService.DeletProduct(id);
          
           
            if(res) return RedirectToAction("index", "Product", new
            {
                res = res
            });


            return BadRequest();
        }
    }
}
