using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Store.AspProject.DataLayer.Context;
using Store.AspProject.DataLayer.Models.Product;
using Store.AspProject.Services.Interfces;
using Store.AspProject.Utilites;

namespace Store.AspProject.Services.Services
{
    public class ProductService : IProductService
    {
        AspStoreDbContext _context;

        public ProductService(AspStoreDbContext context)
        {
            _context = context;
        }

   

        public int AddProductGroup(ProductGroup productGroup)
        {
            _context.productGroups.Add(productGroup);   
            _context.SaveChanges();
            return productGroup.GroupId;
        }

        public bool DeletProduct(int Id)
        {
          var product=  GetProductById(Id);

            _context.Remove(product);   
            _context.SaveChanges();

            return true;
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

       

        public ProductGroup GetProductGroupById(int id)
        {
            return _context.productGroups.Find(id);    
        }

        public List<ShowproductGroupViewModel> GetProductGropuViewModel()
        {
           var res=  _context.productGroups.Select(g => new ShowproductGroupViewModel()
            {
               GroupId = g.GroupId,
               count = g.Products.Count,
               GroupName=g.GroupName
            }).ToList(); 
            return res;
        }

        #region Product

        public int AddProduct(Product product,IFormFile Img)
        {
            //uploadimg
            string ImageName = "Default.jpg";
            if(Img!=null)
            {
                ImageName=CodeGenrator.GenratinUniqCode()+Path.GetExtension(Img.FileName);
                string ImagePath =ImagesfilePath.ProductImageServer+ImageName;
                using(var stream=new FileStream(ImagePath,FileMode.Create))
                {
                    Img.CopyTo(stream);
                }
            }

            product.ImageName = ImageName;  
            product.CreateDate = DateTime.Now;
            _context.Add(product);
            _context.SaveChanges();

            return product.ProductId;
        }

        public int EditProduct(int id, Product product, IFormFile? Img)
        {
            if (Img != null)
            {
                if (product.ImageName != "Default.jpg")
                {
                    string deletePath =
                              ImagesfilePath.ProductImageServer +
                              product.ImageName;
                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }
                }
                string ImageName = CodeGenrator.GenratinUniqCode() + Path.GetExtension(Img.FileName);
                string ImagePath = ImagesfilePath.ProductImageServer + ImageName;
                using (var stream = new FileStream(ImagePath, FileMode.Create))
                {
                    Img.CopyTo(stream);
                }
                product.ImageName = ImageName;
            }
           

          
            product.CreateDate = DateTime.Now;
            _context.Update(product);
            _context.SaveChanges();

            return product.ProductId;
        }

        public List<ProductGroup> GetAll()
        {
            return _context.productGroups.ToList(); 
        }

        public List<Product> GetAllProduct()
        {

            
            return _context.products.Include(p=>p.ProductGroup).ToList();
        }




        public Product GetProductById(int id)
        {
            return _context.products.Find(id);
        }

        public bool EditProduct(Product product)
        {
            _context.products.Update(product);
            _context.SaveChanges();
            return true;
        }

        public List<Product> GetProductBySearch(string Title)
        {
           return _context.products.Where(o=>o.ProductTitle.Contains(Title) || o.ProductHeadTitle.Contains(Title)
           || o.Tags.Contains(Title)).ToList();
        }

        public Tuple<List<Product>, int> GetAllProductForPaging(int PageId = 1, string? Title = "")
        {
            var take = 2;
            int skip = (PageId - 1) * take;

            IQueryable<Product> result = _context.products;

            if(!string.IsNullOrEmpty(Title))
            {
                result=result.Where(p=>p.ProductTitle.Contains(Title));    
            }

           int pagecount= result.Count() / take;
         

            var query=result.Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pagecount);  
        }






        #endregion
    }
}
