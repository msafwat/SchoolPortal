using System;
using NUnit.Framework;
using DataAccessLayer.UnitsOfWork;
using DataAccessLayer.Repositories;
using Entities.School;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Tests
{
    [TestFixture]
    public class SchoolRepositoryUnitTest
    {
        [TestCase("My School 1", "مدرستي 1")]
        public async static void AddSchool(string nameEn, string nameAr)
        {
            // ARRANGE
            var unit = UnitOfWorkFactory.Create();
            var repo = unit.GetSchoolRepository();

            School school = new School()
            {
                NameEn = nameEn,
                NameAr = nameAr
            };

            // Act
            repo.Delete(s => s.NameEn == nameEn && s.NameAr == s.NameAr);
            School schoolResult = repo.Insert(school);
            var x = await unit.Save();

            // Assert
            Assert.That(schoolResult.Id, Is.GreaterThan(0), 
                "Expected That School Got Id Number.");
        }

        [TestCase("My School 1", "مدرستي 1")]
        public static void GetSchool(string nameEn, string nameAr)
        {
            // ARRANGE

            // Act
            var unit = UnitOfWorkFactory.Create();
            var repo = unit.GetSchoolRepository();
            var result = repo.Get(s=>s.NameEn == nameEn && s.NameAr == s.NameAr);

            // Assert
            Assert.That(result, Is.Not.Null,
                "Expected That To Find The School.");
            Assert.That(result.Count(), Is.EqualTo(1),
                "Expected That To Find The School.");
        }
    }
}
