using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.AspProject.DataLayer.Models.Product;
using Store.AspProject.DataLayer.Models.User;

namespace Store.AspProject.DataLayer.Context
{
    public class AspStoreDbContext : IdentityDbContext/*, IDbContext*/
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
        public DbSet<Product> Products { get; set; }

        //ISet<TEntity> IDbContext.Set<TEntity>()
        //{
        //    return (ISet<TEntity>)base.Set<TEntity>();
        //}
    }
}
