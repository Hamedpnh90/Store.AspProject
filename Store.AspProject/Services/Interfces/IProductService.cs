using Store.AspProject.DataLayer.Models.Product;

namespace Store.AspProject.Services.Interfces
{
    public interface IProductService
    {


        #region ProductGroup
        int AddProductGroup(ProductGroup productGroup);

        List<ProductGroup> GetAll();

        ProductGroup GetProductGroupById(int id);


        bool DeletProductGroup(int Id);


        bool EditProductGroup(ProductGroup productGroup);

        List<ShowproductGroupViewModel> GetProductGropuViewModel();
        #endregion


        #region Product

        int AddProduct(Product product, IFormFile Img);

        List<Product> GetAllProduct();

        Product GetProductById(int id);


        bool DeletProduct(int Id);


        bool EditProduct(Product product);
        #endregion







    }
}
