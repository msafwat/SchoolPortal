﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public interface IRepository<TEntity>
    {
        TEntity Insert(TEntity entity);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        TEntity GetByID(object id);

        void Update(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entity);
    }
}