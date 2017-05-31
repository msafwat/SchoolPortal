using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitsOfWork
{
    public static class UnitOfWorkFactory
    {
        public static IUnitOfWork Create(UnitOfWorkStoreEnum unitOfWorkStore = UnitOfWorkStoreEnum.SQL_SERVER)
        {
            switch (unitOfWorkStore)
            {
                case UnitOfWorkStoreEnum.REDIS:
                    return new RedisStoreUnitOfWork(); 
                default:
                    return new SQLServerStoreUnitOfWork();
            }
        }

        private static Dictionary<UnitOfWorkStoreEnum, IUnitOfWork> listUnitOfWorks = new Dictionary<UnitOfWorkStoreEnum, IUnitOfWork>();
        private static object syncLock = new object();

        public static IUnitOfWork CreateSingleton(UnitOfWorkStoreEnum unitOfWorkStore = UnitOfWorkStoreEnum.SQL_SERVER)
        {
            if (!listUnitOfWorks.ContainsKey(unitOfWorkStore))
            {
                lock (syncLock)
                {
                    listUnitOfWorks[unitOfWorkStore] = Create(unitOfWorkStore);
                }
            }

            return listUnitOfWorks[unitOfWorkStore];
        }
    }
}
