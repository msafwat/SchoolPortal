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
        public static IUnitOfWork Create()
        {
            UnitOfWorkStoreEnum unitOfWorkStore = (UnitOfWorkStoreEnum)Convert.ToInt32(ConfigurationManager.AppSettings["StoreMode"]);
            switch (unitOfWorkStore)
            {
                case UnitOfWorkStoreEnum.FILE:
                    return new FileStoreUnitOfWork(); 
                default:
                    return new SQLServerStoreUnitOfWork();
            }
        }

        private static IUnitOfWork _instance;
        private static object syncLock = new object();

        public static IUnitOfWork CreateSingleton()
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = Create();
                    }
                }
            }

            return _instance;
        }
    }
}
