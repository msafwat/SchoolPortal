using ServiceStack.Caching.Memcached;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    internal class MemcachedRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private MemcachedClientCache memcached;

        public MemcachedRepository(MemcachedClientCache memcached)
        {
            this.memcached = memcached;
        }


        public TEntity Insert(TEntity entity)
        {
            try
            {
                var result = memcached.Add<TEntity>("3", entity) ? entity : null;
                return result;
            }
            catch (Exception ex)
            {
                Logger.Logger.LogException(ex);
                return null;
            }
        }

        public List<TEntity> Insert(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public TEntity GetByID(object id)
        {
            throw new NotImplementedException();
        }


        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }


        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
