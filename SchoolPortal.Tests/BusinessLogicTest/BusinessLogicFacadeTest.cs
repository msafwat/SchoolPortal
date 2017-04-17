using BusinessLogicLayer;
using Entities;
using Entities.QuestionsBank;
using GlobalizationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolPortal.Tests.BusinessLogicTest
{
    [TestClass]
    public class BusinessLogicFacadeTest
    {
        [TestMethod]
        public void AddQuestion()
        {
            
            BusinessLogicFacade facade = new BusinessLogicFacade();
            var res = facade.AddQuestion(new Question()
            {
                Text = "sdf"
            });

            Assert.AreEqual(res.Message, "General Error");


            //ResourcesHelper.SetCulutre("ar-EG");
            //res = facade.AddQuestion(new Question()
            //{
            //    Details = "sdf"
            //});

            //Assert.AreEqual(res.Message, "خطا عام");

            //ResourcesHelper.SetCulutre("fr-FR");
            //res = facade.AddQuestion(new Question()
            //{
            //    Details = "sdf"
            //});

            //Assert.AreEqual(res.Message, "General Error");
        }
    }
}
