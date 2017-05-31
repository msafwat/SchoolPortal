using System;
using NUnit.Framework;
using DataAccessLayer.UnitsOfWork;
using DataAccessLayer.Repositories;
using Entities.School;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Tests
{
    [TestFixture]
    public class SchoolRepositoryUnitTest
    {
        [TestCase("My School 1", "مدرستي 1"), Order(1)]
        public async static Task AddSchool(string nameEn, string nameAr)
        {
            // ARRANGE
            var unit = UnitOfWorkFactory.CreateSingleton();
            var repo = unit.GetSchoolRepository();

            var unitCache = UnitOfWorkFactory.CreateSingleton(UnitOfWorkStoreEnum.REDIS);
            var repoCache = unitCache.GetSchoolRepository();

            School school = new School()
            {
                NameEn = nameEn,
                NameAr = nameAr
            };

            // Act
            unit.BeginTransaction();
            repo.Delete(s => s.NameEn == nameEn && s.NameAr == s.NameAr);
            School schoolResult = repo.Insert(school);
            var x = await unit.Save();

            repoCache.Delete();
            repoCache.Insert(schoolResult);

            // Assert
            Assert.That(schoolResult.Id, Is.GreaterThan(0), 
                "Expected That School Got Id Number.");
        }

        [TestCase("My School 1", "مدرستي 1"), Order(2)]
        public static void GetSchool(string nameEn, string nameAr)
        {
            // ARRANGE
            var unit = UnitOfWorkFactory.CreateSingleton();
            var repo = unit.GetSchoolRepository();

            var unitCache = UnitOfWorkFactory.CreateSingleton(UnitOfWorkStoreEnum.REDIS);
            var repoCache = unitCache.GetSchoolRepository();

            // Act
            var result = repo.Get(s=>s.NameEn == nameEn && s.NameAr == s.NameAr);

            List<School> cacheResult = new List<School>();
            repoCache.Get(null, null, null, cacheResult);
            unitCache.CommitTransaction();
            unitCache.Dispose();

            // Assert
            Assert.That(result, Is.Not.Null,
                "Expected That To Find The School.");
            Assert.That(result.Count(), Is.EqualTo(1),
                "Expected That To Find The School.");
            Assert.That(cacheResult.Count(), Is.GreaterThan(0),
                "Expected That To Find The School In Cache.");
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.FailCount > 0)
            {
                var unit = UnitOfWorkFactory.CreateSingleton();
                unit.RollbackTransaction();
                var unitCache = UnitOfWorkFactory.CreateSingleton(UnitOfWorkStoreEnum.REDIS);
                unitCache.RollbackTransaction();
            }
        }
    }
}
