using BusinessLogicLayer.Helper;
using BusinessLogicLayer.Messages;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitsOfWork;
using Entities;
using Entities.QuestionsBank;
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
        private IUnitOfWork work;
        private IRepository<Question> repo;

        internal QuestionManager()
        {
            work = UnitOfWorkFactory.Create();
            repo = work.GetQuestionRepository();
        }

        internal ResponseCodeMessageListResult<Question> GetQuestions(int userId, int skip, int take)
        {
            try
            {
                List<Question> result = repo.Get
                    (
                        q => (QuestionPrivacyEnum)q.QuestionPrivacyId == QuestionPrivacyEnum.PUBLIC
                          || ((QuestionPrivacyEnum)q.QuestionPrivacyId == QuestionPrivacyEnum.PRIVATE
                          && q.UserId == userId),
                        q => q.OrderByDescending(x => x.LastModifiedDateTime)
                    ).Skip(skip).Take(take).ToList();

                return BusinessHelper.GetResponseListResult(ReponseCode.SUCCESS, result);
            }
            catch (Exception ex)
            {
                SystemLogger.SystemLogger.LogException(ex);
                return BusinessHelper.GetResponseListResult<Question>(ReponseCode.GENERAL_ERROR, null);
            }
        }

        internal ResponseCodeMessage AddQuestion(Question question)
        {
            try
            {
                work.BeginTransaction();
                var result = repo.Insert(question);
                if (result != null && result.Id > 0)
                {
                    work.CommitTransaction();
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
                SystemLogger.SystemLogger.LogException(ex);
                return BusinessHelper.GetResponse(ReponseCode.GENERAL_ERROR);
            }
        }
    }
}
