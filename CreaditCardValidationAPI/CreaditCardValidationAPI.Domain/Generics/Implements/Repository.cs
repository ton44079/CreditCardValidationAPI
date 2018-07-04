using CreditCardValidationAPI.Domain.Generics.Interfaces;
using CreditCardValidationAPI.Domain.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidationAPI.Domain.Generics.Implements
{
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        protected CreditDBEntities _entities;
        protected readonly IDbSet<T> _dbset;

        public Repository(CreditDBEntities context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public virtual IQueryable<T> All()
        {
            return _dbset;
        }

        public async Task<List<T>> WhereAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            List<T> query = await _dbset.Where(predicate).ToListAsync();
            return query;
        }

        public IQueryable<T> Where(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbset.Where(predicate);
            return query;
        }

        public virtual T Add(T entity)
        {
            return _dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return _dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Any(predicate);
        }

    }
}
