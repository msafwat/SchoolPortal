using BusinessLogicLayer.Messages;
using GlobalizationResources;
using GlobalizationResources.Resources.BusinessResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Helper
{
    internal static class BusinessHelper
    {
        internal static string GetGlobalResponseMessage(ReponseCode code)
        {
            switch (code)
            {
                case ReponseCode.SUCCESS:
                    return BusinessReponseMessages.SUCCESS;
                case ReponseCode.DATABASE_ERROR:
                    return BusinessReponseMessages.DATABASE_ERROR;
                case ReponseCode.GENERAL_ERROR:
                    return BusinessReponseMessages.GENERAL_ERROR;
                default:
                    return string.Empty;
            }
        }
        
        public static ResponseCodeMessage GetResponse(ReponseCode code)
        {
            return new ResponseCodeMessage() { Code = code, Message = BusinessHelper.GetGlobalResponseMessage(code) };
        }
    }
}
