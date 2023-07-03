using Store.AspProject.DataLayer.Models;
using System.Collections.Generic;

namespace Store.AspProject.DataLayer.Context
{
    public interface IDbContext
    {

        ISet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}
