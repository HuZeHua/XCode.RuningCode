using Autofac;
using XCode.RuningCode.Core.Infrastucture;
using XCode.RuningCode.Service.Abstracts;

namespace XCode.RuningCode.Service
{
    public class ServiceRegister : IDependencyRegister
    {
        public void RegisterTypes(ContainerBuilder builder)
        {
            //实例，如果有泛型的注入需在此处注入
            builder.RegisterType<Test>().As<ITest>().InstancePerLifetimeScope();
            //builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
        }
    }
}
