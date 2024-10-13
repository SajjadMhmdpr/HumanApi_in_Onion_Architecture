using Data.Context;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Repository.UnitOfWork.Generic.Base;

namespace Repository.UnitOfWork.Generic
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private MyContext _context;
        protected DbSet<T> _entities;

        public GenericRepository(MyContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _entities.Attach(entity);
            }

            _entities.Remove(entity);
        }
        public async Task<bool> Delete(object id)
        {
            var entity = await Get(id);
            if (entity == null)
            {
                return false;
            }
            _entities.Remove(entity);
            return true;
        }

        public async Task<T?> Get(object id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>>? where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
             Func<IQueryable<T>, IQueryable<T>>? include = null)
        {

            IQueryable<T> query = _entities;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderby != null)
            {
                query = orderby(query);
            }

            if (include != null)
            {
                query = include(query);
            }

            //if (includes != "")
            //{
            //    foreach (string include in includes.Split(','))
            //    {
            //        query = query.Include(include);
            //    }
            //}

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(T entity)
        {
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
