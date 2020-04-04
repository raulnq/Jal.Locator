using System;
using System.Linq;
using LightInject;

namespace Jal.Locator.LightInject
{
    public class ServiceLocator : IScopedServiceLocator
    {
        private readonly IServiceFactory _container;

        public ServiceLocator(IServiceFactory container)
        {
            _container = container;
        }

        public TSource Resolve<TSource>() where TSource : class
        {
            return _container.GetInstance<TSource>();
        }

        public TSource Resolve<TSource>(string key) where TSource : class
        {
            return _container.GetInstance<TSource>(key);
        }

        public TSource[] ResolveAll<TSource>() where TSource : class
        {
            var instances = _container.GetAllInstances<TSource>();

            if(instances==null)
            {
                return Array.Empty<TSource>();
            }

            return instances.ToArray();
        }

        public object Resolve(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        public object Resolve(Type service)
        {
            return _container.GetInstance(service);
        }

        public IDisposable BeginScope()
        {
            return _container.BeginScope();
        }
    }
}
