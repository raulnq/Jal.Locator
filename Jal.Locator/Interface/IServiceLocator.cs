using System;

namespace Jal.Locator
{
    public interface IServiceLocator
    {
        TSource Resolve<TSource>() where TSource : class;

        TSource Resolve<TSource>(string key) where TSource : class;

        TSource[] ResolveAll<TSource>() where TSource : class;

        object Resolve(Type service);

        object Resolve(Type service, string key);
    }
}
