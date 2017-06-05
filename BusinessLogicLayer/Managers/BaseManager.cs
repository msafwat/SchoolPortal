using DataAccessLayer.Repositories;
using DataAccessLayer.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Managers
{
    internal abstract class BaseManager <T> where T : class 
    {
        protected IUnitOfWork work;
        protected IRepository<T> repo;

        internal BaseManager()
        {
            work = UnitOfWorkFactory.Create();
    }
    }
}
