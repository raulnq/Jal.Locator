using System;
using System.Linq;
using Jal.Locator.Interface;
using LightInject;

namespace Jal.Locator.LightInject.Impl
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly IServiceContainer _container;

        public ServiceLocator(IServiceContainer container)
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
            var allInstances = _container.GetAllInstances<TSource>();

            if (allInstances != null)
            {
                return allInstances.ToArray();
            }
            else
            {
                return null;
            }               
        }

        public object Resolve(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        public object Resolve(Type service)
        {
            return _container.GetInstance(service);
        }
    }
}
