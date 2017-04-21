
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
                var l = redis.As<TEntity>();
                var xxxx = l.Store(entity);
                

                var tt = redis.GetAllKeys();
                long xa = -3;
                trans.QueueCommand(c => c.AddItemToList(entity.GetType().Name, "asa")); //new JavaScriptSerializer().Serialize(entity)));


                List<string> list = null;
                trans.QueueCommand(c => c.GetAllKeys(), r => list = r);

                return entity;
            }
            catch (Exception ex)
            {
                Logger.Logger.LogException(ex);
                return null;
            }
        }

        public List<TEntity> Insert(List<TEntity> entities)
        {
            trans.QueueCommand(c => c.AddRangeToList(entities[0].GetType().Name, entities.Select(e => new JavaScriptSerializer().Serialize(e)).ToList()));
            return entities;
        }


        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            List<string> list = null;
            trans.QueueCommand(c => c.GetAllItemsFromList(typeof(TEntity).Name), r => list = r);

            if (list == null) return null;

            IEnumerable<TEntity> result = list.Select(x => new JavaScriptSerializer().Deserialize<TEntity>(x));

            if(filter != null)
                result = result.Where(filter.Compile());

            if(orderBy != null)
                return orderBy.Invoke(result.AsQueryable()).ToList();

            return result.ToList();
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
