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
                case UnitOfWorkStoreEnum.FILE:
                    return new CacheStoreUnitOfWork(); 
                default:
                    return new SQLServerStoreUnitOfWork();
            }
        }

        private static IUnitOfWork _instance;
        private static object syncLock = new object();

        public static IUnitOfWork CreateSingleton(UnitOfWorkStoreEnum unitOfWorkStore = UnitOfWorkStoreEnum.SQL_SERVER)
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = Create(unitOfWorkStore);
                    }
                }
            }

            return _instance;
        }
    }
}
