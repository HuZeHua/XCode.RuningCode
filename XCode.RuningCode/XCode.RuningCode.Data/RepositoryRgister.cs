using Autofac;
using XCode.RuningCode.Core.Data;
using XCode.RuningCode.Core.Infrastucture;
using XCode.RuningCode.Data.Data;

namespace XCode.RuningCode.Data
{
    public class RepositoryRgister : IDependencyRegister
    {
        public void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<XCodeContext>().As<IDbContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        }
    }
}
