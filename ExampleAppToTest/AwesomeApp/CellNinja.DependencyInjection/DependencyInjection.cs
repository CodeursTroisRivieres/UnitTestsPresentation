using System;
using SimpleInjector;

namespace CellNinja.DependencyInjection
{
    public static class DependencyInjection
    {
        private static Container _container;

        static DependencyInjection()
        {
            _container = new Container();
        }

        public static void Register<T>()
            where T : class
        {
            _container.Register<T>();
        }

        public static void Register<TInterface, T>()
            where TInterface : class
            where T : class, TInterface
        {
            _container.Register<TInterface, T>();
        }

        public static void Register<TInterface>(Func<TInterface> instanceCreator)
            where TInterface : class
        {
            _container.Register<TInterface>(instanceCreator);
        }

        public static void RegisterSingleton<TInterface, T>()
            where TInterface : class
            where T : class, TInterface
        {
            _container.RegisterSingleton<TInterface, T>();
        }

        public static void RegisterSingleton<TInterface>(Func<TInterface> instanceCreator)
            where TInterface : class
        {
            _container.RegisterSingleton<TInterface>(instanceCreator);
        }

        public static TInterface Get<TInterface>()
            where TInterface : class
        {
            return _container.GetInstance<TInterface>();
        }

        public static void Verify()
        {
            _container.Verify();
        }
    }
}
