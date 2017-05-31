using BusinessLogicLayer.Managers;
using BusinessLogicLayer.Messages;
using Entities;
using Entities.QuestionsBank;
using GlobalizationResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BusinessLogicFacade
    {
        internal ResponseCodeMessageListResult<Question> GetQuestions(int userId, int skip = 0, int take = 16)
        {
            return new QuestionManager().GetQuestions(userId, skip, take);
        }

        public ResponseCodeMessage AddQuestion(Question question)
        {
            return new QuestionManager().AddQuestion(question);
        }
    }
}
