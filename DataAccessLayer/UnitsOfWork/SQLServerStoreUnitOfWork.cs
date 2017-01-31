using DataAccessLayer.DbContexts;
using DataAccessLayer.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitsOfWork
{
    internal class SQLServerStoreUnitOfWork : IUnitOfWork
    {
        private SchoolDbContext context = new SchoolDbContext();
        

        private IRepository<Question> questionRepository;

        public IRepository<Question> GetQuestionRepository()
        {
            if (this.questionRepository == null)
            {
                this.questionRepository = new SQLServerRepository<Question>(context);
            }
            return questionRepository;
        }
        
        public void Save()
        {
            context.SaveChanges();
        }

        public int Execute(string statement, params object[] parameters)
        {
            return context.Database.ExecuteSqlCommand(statement, parameters);
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            context.Database.BeginTransaction(isolationLevel);
        }

        public void CommiTransaction()
        {
            context.Database.CurrentTransaction.Commit();
        }

        public void RollbackTransaction()
        {
            context.Database.CurrentTransaction.Rollback();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
