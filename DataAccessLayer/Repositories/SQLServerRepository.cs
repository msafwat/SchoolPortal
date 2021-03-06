﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    internal class SQLServerRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext db;
        private DbSet<TEntity> dbSet;

        public SQLServerRepository(DbContext db)
        {
            this.db = db;
            this.dbSet = db.Set<TEntity>();
        }


        public TEntity Insert(TEntity entity)
        {
            try
            {
                return dbSet.Add(entity);
            }
            catch (Exception ex)
            {
                SystemLogger.SystemLogger.LogException(ex);
                return null;
            }
        }

        public List<TEntity> Insert(List<TEntity> entities)
        {
            try
            {
                return dbSet.AddRange(entities).ToList();
            }
            catch (Exception ex)
            {
                SystemLogger.SystemLogger.LogException(ex);
                return null;
            }
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", List<TEntity> resultReferance = null)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            TEntity entity = GetByID(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (db.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> filter = null)
        {
            // dbSet.RemoveRange(Get(filter));
        }
    }
}
