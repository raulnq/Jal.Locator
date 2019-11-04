using System;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using Jal.Locator.Interface;

namespace Jal.Locator.CastleWindsor.Impl
{
    public class ServiceLocator : IScopedServiceLocator
    {
        public IWindsorContainer Container { get; set; }

        public TSource Resolve<TSource>() where TSource : class 
        {
            return Container.Resolve<TSource>();
        }

        public IDisposable BeginScope()
        {
            return Container.BeginScope();
        }

        public void Release(object instance)
        {
            Container.Release(instance);
        }

        public TSource Resolve<TSource>(string key) where TSource : class 
        {
            return Container.Resolve<TSource>(key);
        }

        public TSource[] ResolveAll<TSource>() where TSource : class 
        {
            return Container.ResolveAll<TSource>();
        }

        public object Resolve(Type service)
        {
            return Container.Resolve(service);
        }

        public object Resolve(Type service, string key)
        {
            return Container.Resolve(key, service);
        }
    }
}
