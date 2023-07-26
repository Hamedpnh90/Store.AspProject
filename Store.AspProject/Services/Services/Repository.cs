using Store.AspProject.DataLayer.Context;
using Store.AspProject.DataLayer.Models;

using Store.AspProject.Services.Interfces;


namespace Store.AspProject.Services.Services
{
    //public class Repository<T> : IRepository<T> where T : BaseEntity

    //{
    //    private readonly IDbContext _context;
    //    private IDbSet<T> _entities;
       

    //    public Repository(IDbContext context)
    //    {
    //        this._context = context;
    //    }

    //    public T GetById(object id)
    //    {
    //        return this.Entities.Find(id);
    //    }

    //    public void Insert(T entity)
    //    {
            
    //            if (entity == null)
    //            {
    //                throw new ArgumentNullException("entity");
    //            }
    //            this.Entities.Add(entity);
    //            this._context.SaveChanges();
           
            
    //    }

    //    public void Update(T entity)
    //    {
           
    //            if (entity == null)
    //            {
    //                throw new ArgumentNullException("entity");
    //            }
    //            this._context.SaveChanges();
          
    //    }

    //    public void Delete(T entity)
    //    {
           
    //            if (entity == null)
    //            {
    //                throw new ArgumentNullException("entity");
    //            }
    //            this.Entities.Remove(entity);
    //            this._context.SaveChanges();
           
    //    }

    //    public virtual IQueryable<T> Table
    //    {
    //        get
    //        {
    //            return this.Entities;
    //        }
    //    }

    //    private IDbSet<T> Entities
    //    {
    //        get
    //        {
    //            if (_entities == null)
    //            {
    //                _entities = (IDbSet<T>?)_context.Set<T>();
    //            }
    //            return _entities;
    //        }
    //    }
    //}
}
