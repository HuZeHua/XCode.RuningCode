using Autofac;
using XCode.RuningCode.Core.Infrastucture;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Implements;

namespace XCode.RuningCode.Service
{
    public class ServiceRegister : IDependencyRegister
    {
        public void RegisterTypes(ContainerBuilder builder)
        {
            //实例，如果有泛型的注入需在此处注入
            builder.RegisterType<Test>().As<ITest>().InstancePerLifetimeScope();
            builder.RegisterType<EmailPoolService>().As<IEmailPoolService>().InstancePerLifetimeScope();
            builder.RegisterType<EmailReceiverService>().As<IEmailReceiverService>().InstancePerLifetimeScope();
            builder.RegisterType<LoginLogService>().As<ILoginLogService>().InstancePerLifetimeScope();
            builder.RegisterType<MenuService>().As<IMenuService>().InstancePerLifetimeScope();
            builder.RegisterType<PageViewService>().As<IPageViewService>().InstancePerLifetimeScope();
            builder.RegisterType<RoleMenuService>().As<IRoleMenuService>().InstancePerLifetimeScope();
            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthorizeProvider>().As<IAuthorizeProvider>().InstancePerLifetimeScope();
            builder.RegisterType<PermissionProvider>().As<IPermissionProvider>().InstancePerLifetimeScope();
            builder.RegisterType<PermissionService>().As<IPermissionService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
        }
    }
}
