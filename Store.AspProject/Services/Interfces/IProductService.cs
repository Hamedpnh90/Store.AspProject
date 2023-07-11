using Store.AspProject.DataLayer.Models.Product;

namespace Store.AspProject.Services.Interfces
{
    public interface IProductService
    {


        int AddProduct(ProductGroup productGroup); 

        List<ProductGroup> GetAll();

        ProductGroup GetProductGroupById(int id);    


        bool DeletProductGroup(int  Id);


        bool EditProductGroup(ProductGroup productGroup);







    }
}
