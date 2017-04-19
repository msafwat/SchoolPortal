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
using ServiceStack.Caching.Memcached;
using System.Net;

namespace DataAccessLayer.UnitsOfWork
{
    internal class MemcachedStoreUnitOfWork : IUnitOfWork
    {
        private MemcachedClientCache memcached;

        internal MemcachedStoreUnitOfWork()
        {
            memcached = new MemcachedClientCache(new List<IPEndPoint>() { new IPEndPoint(new IPAddress(new byte[] { 127,0,0,1 }), 11211) });
        }

        private IRepository<School> schoolRepository;
        public IRepository<School> GetSchoolRepository()
        {
            if (this.schoolRepository == null)
            {
                this.schoolRepository = new MemcachedRepository<School>(memcached);
            }
            return schoolRepository;
        }

        public IRepository<Question> GetQuestionRepository()
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public IUnitOfWork CreateSingleton()
        {
            throw new NotImplementedException();
        }

        public int Execute(string statement, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
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
                    memcached.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
