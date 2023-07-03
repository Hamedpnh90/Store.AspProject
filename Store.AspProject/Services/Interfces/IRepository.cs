

using Store.AspProject.DataLayer.Context;
using Store.AspProject.DataLayer.Models;
using Store.AspProject.DataLayer.Models.User;

namespace Store.AspProject.Services.Interfces
{
    public interface IRepository<T> where T : BaseEntity
    {

        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
    }
}
