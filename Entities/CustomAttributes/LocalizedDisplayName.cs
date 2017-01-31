using GlobalizationResources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CustomAttributes
{
    public class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        private ResourcesType resourceType;
        private string resourceName;

        public LocalizedDisplayNameAttribute(ResourcesType resourceType, string resourceName) : base(resourceName)
        {
            this.resourceType = resourceType;
            this.resourceName = resourceName;
        }

        public override string DisplayName
        {
            get
            {
                return ResourcesHelper.GetValue(resourceType, resourceName);
            }
        }
    }
}
