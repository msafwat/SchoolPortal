using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;
using Entities;
using Entities.QuestionsBank;

namespace DataAccessLayer.UnitsOfWork
{
    internal class FileStoreUnitOfWork : IUnitOfWork
    {
        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            throw new NotImplementedException();
        }

        public void CommiTransaction()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int Execute(string statement, params object[] parameters)
        {
            throw new NotImplementedException();
        }
        
        public IRepository<Question> GetQuestionRepository()
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
    }
}
