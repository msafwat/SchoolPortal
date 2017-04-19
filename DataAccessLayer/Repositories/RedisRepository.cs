using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    internal class RedisRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public TEntity Insert(TEntity entity)
        {
            throw new NotImplementedException();
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
