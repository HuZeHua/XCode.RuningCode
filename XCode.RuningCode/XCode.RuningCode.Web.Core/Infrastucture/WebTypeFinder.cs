using System;
using System.Collections.Generic;
using System.Reflection;
using CarManager.Core.Infrastructure;

namespace XCode.RuningCode.Web.Core.Infrastucture
{
    public class WebTypeFinder : AppDomainTypeFinder
    {
        private bool binFolderAssembliesLoaded = false;

        public virtual string GetBinDirectory()
        {
            if (System.Web.Hosting.HostingEnvironment.IsHosted)
            {
                return System.Web.HttpRuntime.BinDirectory;
            }

            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public override IList<Assembly> GetAssemblies()
        {
            if (!binFolderAssembliesLoaded)
            {
                binFolderAssembliesLoaded = true;
                LoadMatchingAssemblies(GetBinDirectory());
            }
            return base.GetAssemblies();
        }
    }
}
