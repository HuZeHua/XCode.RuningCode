using System;
using System.Collections.Generic;
using System.Reflection;
using XCode.RuningCode.Core.Infrastucture;

namespace XCode.RuningCode.Web.Infrastucture
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
