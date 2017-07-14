using shoppingCart.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace shoppingCart.GenericRepository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public void Create(TEntity instance)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity instance)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity instance)
        {
            throw new NotImplementedException();
        }
        
        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}