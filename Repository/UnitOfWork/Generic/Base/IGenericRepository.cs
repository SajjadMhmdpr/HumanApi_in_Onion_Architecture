using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork.Generic.Base
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>>? where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
            Func<IQueryable<T>, IQueryable<T>>? include = null);
        Task<T?> Get(object id);
        Task Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> Delete(object id);
        Task<bool> SaveChanges();
    }
}
