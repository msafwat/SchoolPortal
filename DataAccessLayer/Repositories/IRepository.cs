using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IRepository<TEntity>
    {
        TEntity Insert(TEntity entity);

        List<TEntity> Insert(List<TEntity> entities);


        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        TEntity GetByID(object id);


        void Update(TEntity entity);


        void Delete(object id);

        void Delete(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> filter);
    }
}