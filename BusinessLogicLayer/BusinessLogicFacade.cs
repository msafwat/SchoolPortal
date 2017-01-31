using BusinessLogicLayer.Managers;
using BusinessLogicLayer.Messages;
using Entities;
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

        public ResponseCodeMessage AddQuestion(Question question)
        {
            return new QuestionManager().AddQuestion(question);
        }
    }
}
