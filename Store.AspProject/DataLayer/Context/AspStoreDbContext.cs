using Microsoft.EntityFrameworkCore;
using Store.AspProject.DataLayer.Models.User;

namespace Store.AspProject.DataLayer.Context
{
    public class AspStoreDbContext : DbContext, IDbContext
    {

        public AspStoreDbContext(DbContextOptions<AspStoreDbContext> options):base(options)
        {

        }


        public DbSet<User> users { get; set; }

        ISet<TEntity> IDbContext.Set<TEntity>()
        {
            return (ISet<TEntity>)base.Set<TEntity>();
        }
    }
}
