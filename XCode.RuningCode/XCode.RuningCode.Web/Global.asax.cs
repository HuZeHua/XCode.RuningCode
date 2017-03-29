using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using XCode.RuningCode.Core.Infrastucture;
using XCode.RuningCode.Service;
using XCode.RuningCode.Service.Data;
using XCode.RuningCode.Web.Jobs;

namespace XCode.RuningCode.Web
{
    public class MvcApplication : HttpApplication
    {
        /// <summary>
        /// Application_Start
        /// </summary>
        protected void Application_Start()
        {

            //MVC相关
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //初始化容器
            XCodeContainer.CreateInstance();
            ////DI 构造函数注入
            IocInitializeConstructor.Initialize();
            //属性注入
            //new IocInitializeProperties().Initialize();

            //数据库基础数据初始化
            DbInitService.Init();

            //定时任务
            //new EmailJobScheduler().Start();


            //AutoMapper
            AutoMapperConfiguration.Config();
            AutoMapperConfiguration.ConfigExt();
        }
    }
}
