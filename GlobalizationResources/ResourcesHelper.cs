using GlobalizationResources.Resources.BusinessResponse;
using GlobalizationResources.Resources.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GlobalizationResources
{
    public static class ResourcesHelper
    {
        public static void SetCulutre(string culutre)
        {
            CultureInfo cultureInfo = new CultureInfo(culutre);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        public static string GetValue(ResourcesType resourceType, string resourceName)
        {

            switch (resourceType)
            {
                case ResourcesType.BusinessReponseMessages:
                    return new ResourceManager("GlobalizationResources.Resources.BusinessResponse.BusinessReponseMessages", Assembly.GetExecutingAssembly()).GetString(resourceName);
                case ResourcesType.Questions:
                    return new ResourceManager(typeof(Questions)).GetString(resourceName);
                default:
                    return string.Empty;
            }
        }
    }
}
