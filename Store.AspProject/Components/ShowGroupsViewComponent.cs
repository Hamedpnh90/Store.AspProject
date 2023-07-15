using Microsoft.AspNetCore.Mvc;
using Store.AspProject.Services.Interfces;

namespace Store.AspProject.Components
{
    public class ShowGroupsViewComponent:ViewComponent
    {
        private readonly IProductService _productService;

        public ShowGroupsViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
           var Result=_productService.GetProductGropuViewModel();

            return View(Result);
        }    
    }
}
