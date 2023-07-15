using Microsoft.AspNetCore.Mvc;
using Store.AspProject.DataLayer.Models.Product;
using Store.AspProject.Services.Interfces;

namespace Store.AspProject.Areas.Admin.Controllers

{

    [Area("Admin")]
    public class ProductGroupController : Controller
    {
        private readonly IProductService _productService;

        public ProductGroupController(IProductService ProductService)
        {
           _productService = ProductService;
        }
        public IActionResult Index()
        {

            return View(_productService.GetAll());
        }
      
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost("Admin/ProductGroup")]

        public IActionResult Create(ProductGroup productGroup)
        {
            _productService.AddProductGroup(productGroup);

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int Id)
        {
            return View(_productService.GetProductGroupById(Id));
        }


        [HttpPost]
        public IActionResult Edit(ProductGroup productGroup)
        {
            

            if(productGroup == null) return NotFound();
            
              var res=  _productService.EditProductGroup(productGroup);
            
            if(!res) return BadRequest();   

            return Redirect("/admin/ProductGroup/index");
        }

        public IActionResult Delete(int id)
        {
            return View(_productService.GetProductGroupById(id));
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            _productService.DeletProductGroup(id);

            return Redirect("/admin/ProductGroup/index");
        }
    }
}