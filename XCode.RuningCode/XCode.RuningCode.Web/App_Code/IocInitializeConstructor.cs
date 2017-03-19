using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using XCode.RuningCode.Core.Data;
using XCode.RuningCode.Core.Infrastucture;
using XCode.RuningCode.Data.Data;
using XCode.RuningCode.Web.Infrastucture;

namespace XCode.RuningCode.Web
{
    /// <summary>
    /// AutoFac构造函数IOC初始化
    /// </summary>
    public class IocInitializeConstructor
    {
        /// <summary>
        /// 获取或设置 Autofac组合IContainer
        /// </summary>
        protected IContainer Container { get; set; }

        public IocInitializeConstructor()
        {
            ContainerBuilder builder = new ContainerBuilder();
            Container = builder.Build();
        }
        /// <summary>
        /// 依赖注入初始化
        /// </summary>
        public void Initialize()
        {
            register_dependency();
            //Type baseType = typeof(IDependency);
            //Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies().ToArray();//获取已加载到此应用程序域的执行上下文中的程序集。
            //Type[] dependencyTypes = assemblies
            //    .SelectMany(s => s.GetTypes())
            //    .Where(p => baseType.IsAssignableFrom(p) && p != baseType).ToArray();//得到接口和实现类
            //RegisterDependencyTypes(dependencyTypes);//第一步：注册类型

            //SetResolver(assemblies);//第二步：
        }

        private void register_dependency()
        {
            //依赖项 => dependencies
            var typeFinder = new WebTypeFinder();
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();
            builder.Update(Container);

            //找到其他程序集中实现IDependencyRegistrar的类 => register dependencies provided by other assemblies
            builder = new ContainerBuilder();
            var drTypes = typeFinder.FindClassesOfType<IDependencyRegister>();
            var drInstances = new List<IDependencyRegister>();
            foreach (var drType in drTypes)
                drInstances.Add((IDependencyRegister)Activator.CreateInstance(drType));
            //sort
            drInstances = drInstances.AsQueryable().ToList();
            foreach (var dependencyRegistrar in drInstances)
                dependencyRegistrar.RegisterTypes(builder);
            builder.Update(Container);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }

        /// <summary>
        /// 实现依赖注入接口<see cref="IDependency"/>实现类型的注册
        /// </summary>
        /// <param name="types">要注册的类型集合</param>
        protected void RegisterDependencyTypes(Type[] types)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<XCodeContext>()
                .As<IDbContext>()
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            //builder.RegisterType<DbContextScopeFactory>()
            //    .As<IDbContextScopeFactory>()
            //    .AsSelf()
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            

            builder.RegisterTypes(types)
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();//所有实现IDependency的注册为InstancePerLifetimeScope生命周期
            builder.Update(Container);
        }

        /// <summary>
        /// 设置MVC的DependencyResolver注册点
        /// </summary>
        /// <param name="assemblies"></param>
        protected void SetResolver(Assembly[] assemblies)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(assemblies)
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.Update(Container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }

    }
}