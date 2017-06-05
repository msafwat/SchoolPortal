using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;
using Entities;
using Entities.QuestionsBank;
using Entities.School;
using System.Net;
using ServiceStack.Redis;
using Entities.SchoolStakeholders;

namespace DataAccessLayer.UnitsOfWork
{
    internal class RedisStoreUnitOfWork : IUnitOfWork
    {
        private RedisManagerPool redisManager;
        private IRedisClient redis;
        private IRedisTransaction trans;

        internal RedisStoreUnitOfWork()
        {
            redisManager = new RedisManagerPool("127.0.0.1:6379");
            redis = redisManager.GetClient();
            trans = redis.CreateTransaction();
        }

        private IRepository<School> schoolRepository;
        public IRepository<School> GetSchoolRepository()
        {
            if (this.schoolRepository == null)
            {
                this.schoolRepository = new RedisRepository<School>(redis, trans);
            }
            return schoolRepository;
        }

        public IRepository<Question> GetQuestionRepository()
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if(trans == null)
                trans = redis.CreateTransaction();
        }

        public void CommitTransaction()
        {
            trans.Commit();
        }
        
        public void RollbackTransaction()
        {
            trans.Dispose();
        }

        public int Execute(string statement, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Save()
        {
            throw new NotImplementedException();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    trans.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<Student> GetStudentRepository()
        {
            throw new NotImplementedException();
        }
    }
}
