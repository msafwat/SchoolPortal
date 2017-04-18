using DataAccessLayer.DbContexts;
using DataAccessLayer.Repositories;
using Entities;
using Entities.QuestionsBank;
using Entities.SchoolStakeholders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.School;

namespace DataAccessLayer.UnitsOfWork
{
    internal class SQLServerStoreUnitOfWork : IUnitOfWork
    {
        private SchoolDbContext context = new SchoolDbContext("SchoolDBContextCS");


        private IRepository<School> schoolRepository;
        public IRepository<School> GetSchoolRepository()
        {
            if (this.studentRepository == null)
            {
                this.schoolRepository = new SQLServerRepository<School>(context);
            }
            return schoolRepository;
        }

        private IRepository<Student> studentRepository;
        public IRepository<Student> GetStudentRepository()
        {
            if (this.studentRepository == null)
            {
                this.studentRepository = new SQLServerRepository<Student>(context);
            }
            return studentRepository;
        }

        private IRepository<Question> questionRepository;

        public IRepository<Question> GetQuestionRepository()
        {
            if (this.questionRepository == null)
            {
                this.questionRepository = new SQLServerRepository<Question>(context);
            }
            return questionRepository;
        }
        
        public async Task<int> Save()
        {
            try
            {
                return await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Logger.Logger.LogException(ex);
                return -1;
            }
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
