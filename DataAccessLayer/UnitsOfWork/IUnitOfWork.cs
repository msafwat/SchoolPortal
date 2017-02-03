using DataAccessLayer.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Question> GetQuestionRepository();

        Task<int> Save();

        int Execute(string statement, params object[] parameters);

        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        void CommiTransaction();

        void RollbackTransaction();
    }
}
