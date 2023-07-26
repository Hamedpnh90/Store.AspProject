using Microsoft.EntityFrameworkCore;
using Store.AspProject.DataLayer.Models.Order;
using Store.AspProject.DataLayer.Models.Product;
using Store.AspProject.DataLayer.Models.user;


namespace Store.AspProject.DataLayer.Context
{
    public class AspStoreDbContext : DbContext/*, IDbContext*/
    {

        public AspStoreDbContext(DbContextOptions<AspStoreDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user>().HasQueryFilter(x => !x.IsDeleted);   

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<user> users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductGroup> productGroups { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        //ISet<TEntity> IDbContext.Set<TEntity>()
        //{
        //    return (ISet<TEntity>)base.Set<TEntity>();
        //}
    }
}
