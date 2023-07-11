using Store.AspProject.DataLayer.Context;
using Store.AspProject.DataLayer.Models.Product;
using Store.AspProject.Services.Interfces;

namespace Store.AspProject.Services.Services
{
    public class ProductService : IProductService
    {
        AspStoreDbContext _context;

        public ProductService(AspStoreDbContext context)
        {
            _context = context;
        }

        public int AddProduct(ProductGroup productGroup)
        {
            _context.productGroups.Add(productGroup);   
            _context.SaveChanges();
            return productGroup.GroupId;
        }

        public bool DeletProductGroup(int Id)
        {
            ProductGroup productGroup= GetProductGroupById(Id);
            if (productGroup == null) return false;  
            _context.Remove(productGroup);
            _context.SaveChanges(); 
            return true;
        }

        public bool EditProductGroup(ProductGroup productGroup)
        {
            _context.Update(productGroup);
            _context.SaveChanges();
            return true;
        }

        public List<ProductGroup> GetAll()
        {
          return  _context.productGroups.ToList();
        }

        public ProductGroup GetProductGroupById(int id)
        {
            return _context.productGroups.Find(id);    
        }
    }
}
