using DataAccessLayer.DbContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DbContexts
{
    internal class SchoolDbContextInitializer : CreateDatabaseIfNotExists<SchoolDbContext>
    {
        protected void Seed(SchoolDbContext context)
        {
            base.Seed(context);
        }
    }
}
