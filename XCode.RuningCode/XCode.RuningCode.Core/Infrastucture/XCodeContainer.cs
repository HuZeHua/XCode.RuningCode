using Autofac;

namespace XCode.RuningCode.Core.Infrastucture
{
    public class XCodeContainer
    {
        private static volatile XCodeContainer instance = null;
        private static readonly object LockHelper = new object();
        private static readonly IContainer Container;

        static XCodeContainer()
        {
            var builder = new ContainerBuilder();
            Container = builder.Build();
        }

        public static XCodeContainer CreateInstance()
        {
            if (instance != null) return instance;
            lock (LockHelper)
            {
                if (instance == null)
                    return instance ?? (instance = new XCodeContainer());
            }
            return instance;
        }

        public static IContainer Current { get { return Container; } }

        public static T Resolve<T>() where T : class
        {
            return Container.Resolve<T>();
        }
    }
}
