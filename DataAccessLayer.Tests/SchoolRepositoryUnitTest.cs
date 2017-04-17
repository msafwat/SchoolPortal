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
        public static void AddSchool(string nameEn, string nameAr)
        {
            // ARRANGE
            School school = new School()
            {
                NameEn = nameEn,
                NameAr = nameAr
            };

            // Act
            var schoolRepo = UnitOfWorkFactory.Create().GetSchoolRepository();
            School schoolResult = schoolRepo.Insert(school);

            // Assert
            Assert.That(schoolResult.Id, Is.GreaterThan(0), 
                "Expected That School Got Id Number.");
        }
    }
}
