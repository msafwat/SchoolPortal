
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DataAccessLayer.Repositories
{
    internal class RedisRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IRedisClient redis;
        private IRedisTransaction trans;

        public RedisRepository(IRedisClient redis, IRedisTransaction trans)
        {
            this.redis = redis;
            this.trans = trans;
        }


        public TEntity Insert(TEntity entity)
        {
            try
            {
                trans.QueueCommand(c => c.AddItemToList(entity.GetType().Name, new JavaScriptSerializer().Serialize(entity)));
                return entity;
            }
            catch (Exception ex)
            {
                SystemLogger.SystemLogger.LogException(ex);
                return null;
            }
        }

        public List<TEntity> Insert(List<TEntity> entities)
        {
            trans.QueueCommand(c => c.AddRangeToList(entities[0].GetType().Name, entities.Select(e => new JavaScriptSerializer().Serialize(e)).ToList()));
            return entities;
        }
        
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", List<TEntity> resultReferance = null)
        {
            if(resultReferance == null) resultReferance = new List<TEntity>();

            trans.QueueCommand(c => c.GetAllItemsFromList(typeof(TEntity).Name), 
                r =>
                {
                    if (r == null) resultReferance = null;
                    var temp = r.Select(x => new JavaScriptSerializer().Deserialize<TEntity>(x));  
                    if (filter != null) temp = temp.Where(filter.Compile());
                    if (orderBy != null) temp = orderBy.Invoke(temp.AsQueryable()).ToList();
                    foreach (var t in temp) resultReferance.Add(t);
                }
                );

            return resultReferance;
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

        public void Delete(Expression<Func<TEntity, bool>> filter = null)
        {
            trans.QueueCommand(c => c.RemoveAllFromList(typeof(TEntity).Name));
        }
    }
}
