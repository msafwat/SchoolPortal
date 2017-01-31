using DataAccessLayer.Repositories;
using DataAccessLayer.UnitsOfWork;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPortal.Tests.DataAccessTest
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void AddStudent()
        {
            //IUnitOfWork work = UnitOfWorkFactory.Create();
            //IRepository<Student> repo = work.GetStudentRepository();

            //Student student = new Student()
            //{
            //    FirstName = "Moustafa",
            //    MiddledName = "Safwat",
            //    LastName = "ElSayed",
            //    BirthDate = DateTime.Now
            //};

            //var school = student.SchoolCurriculums.Single(x => x.StudentId == 1 && x.SchoolCurriculum.SchoolYear.Year.id == 2017).SchoolCurriculum.SchoolYear.School;

            //work.BeginTransaction();

            //repo.Insert(student);
            //if (student.Id < 0)
            //{

            //}


            //work.CommiTransaction();

        }
    }
}
