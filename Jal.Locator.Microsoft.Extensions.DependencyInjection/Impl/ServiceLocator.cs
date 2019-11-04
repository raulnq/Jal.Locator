using Jal.Locator.Interface;
using System;
using System.Linq;
using Jal.Locator.Microsoft.Extensions.DependencyInjection.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Jal.Locator.Microsoft.Extensions.DependencyInjection.Impl
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly IServiceProvider _container;

        private readonly INamedServiceProvider _namedcontainer;

        public ServiceLocator(IServiceProvider container, INamedServiceProvider namedcontainer)
        {
            _container = container;

            _namedcontainer = namedcontainer;
        }

        public TSource Resolve<TSource>() where TSource : class
        {
            return _container.GetRequiredService<TSource>();
        }

        public TSource Resolve<TSource>(string key) where TSource : class
        {
            return _namedcontainer.GetService(typeof(TSource), key) as TSource;
        }

        public object Resolve(Type service)
        {
            return _container.GetRequiredService(service);
        }

        public object Resolve(Type service, string key)
        {
            return _namedcontainer.GetService(service, key);
        }

        public TSource[] ResolveAll<TSource>() where TSource : class
        {
            return _container.GetServices<TSource>()?.ToArray();
        }
    }
}
