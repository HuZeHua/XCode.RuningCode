using Autofac;

namespace XCode.RuningCode.Core.Infrastucture
{
    public interface IDependencyRegister
    {
        void RegisterTypes(ContainerBuilder builder);
    }
}
