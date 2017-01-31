using BusinessLogicLayer.Helper;
using BusinessLogicLayer.Messages;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitsOfWork;
using Entities;
using GlobalizationResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Managers
{
    internal class QuestionManager
    {
        internal ResponseCodeMessage AddQuestion(Question question)
        {
            try
            {
                IUnitOfWork work = UnitOfWorkFactory.Create();
                IRepository<Question> repo = work.GetQuestionRepository();

                work.BeginTransaction();
                var result = repo.Insert(question);
                if (result != null && result.Id > 0)
                {
                    work.CommiTransaction();
                    return BusinessHelper.GetResponse(ReponseCode.SUCCESS);
                }
                else
                {
                    work.RollbackTransaction();
                    return BusinessHelper.GetResponse(ReponseCode.DATABASE_ERROR);
                }
            }
            catch (Exception ex)
            {
                // Log
                return BusinessHelper.GetResponse(ReponseCode.GENERAL_ERROR);
            }
        }
    }
}
