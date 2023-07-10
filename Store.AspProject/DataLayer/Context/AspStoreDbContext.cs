using Microsoft.EntityFrameworkCore;
using Store.AspProject.DataLayer.Models.Product;
using Store.AspProject.DataLayer.Models.User;

namespace Store.AspProject.DataLayer.Context
{
    public class AspStoreDbContext : DbContext/*, IDbContext*/
    {

        public AspStoreDbContext(DbContextOptions<AspStoreDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);   

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductGroup> productGroups { get; set; }

        //ISet<TEntity> IDbContext.Set<TEntity>()
        //{
        //    return (ISet<TEntity>)base.Set<TEntity>();
        //}
    }
}
