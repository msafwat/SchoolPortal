using System;
using NUnit.Framework;
using DataAccessLayer.UnitsOfWork;
using DataAccessLayer.Repositories;
using Entities.School;

namespace DataAccessLayer.Tests
{
    [TestFixture]
    public class SchoolRepositoryUnitTest
    {
        [TestCase("My School 1", "مدرستي 1")]
        public async static void AddSchool(string nameEn, string nameAr)
        {
            // ARRANGE
            School school = new School()
            {
                NameEn = nameEn,
                NameAr = nameAr
            };

            // Act
            var unit = UnitOfWorkFactory.Create();
            var repo = unit.GetSchoolRepository();
            School schoolResult = repo.Insert(school);
            var x = await unit.Save();

            // Assert
            Assert.That(schoolResult.Id, Is.GreaterThan(0), 
                "Expected That School Got Id Number.");
        }
    }
}
