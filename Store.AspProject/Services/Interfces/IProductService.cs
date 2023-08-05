using Store.AspProject.DataLayer.Models.Product;

namespace Store.AspProject.Services.Interfces
{
    public interface IProductService
    {


        #region ProductGroup
        int AddProductGroup(ProductGroup productGroup);

        List<ProductGroup> GetAll();
        List<Product> GetProductBySearch(string Title);

        ProductGroup GetProductGroupById(int id);


        bool DeletProductGroup(int Id);


        bool EditProductGroup(ProductGroup productGroup);

        List<ShowproductGroupViewModel> GetProductGropuViewModel();
        #endregion


        #region Product

        int AddProduct(Product product, IFormFile Img);

        int EditProduct(int id,Product product, IFormFile? Img);


        List<Product> GetAllProduct();
        Tuple<List<Product>,int> GetAllProductForPaging(int PageId=1,string? Title="");

        Product GetProductById(int id);


        bool DeletProduct(int Id);


        bool EditProduct(Product product);
        #endregion







    }
}
