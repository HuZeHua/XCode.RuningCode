using System.Web.Mvc;
using XCode.RuningCode.Web.Filter;

namespace XCode.RuningCode.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CommonExceptionFilter());
            filters.Add(new AuthFilter());
        }
    }
}