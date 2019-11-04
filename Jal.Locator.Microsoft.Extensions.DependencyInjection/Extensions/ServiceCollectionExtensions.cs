using Jal.Locator.Interface;
using System;
using Microsoft.Extensions.DependencyInjection;
using Jal.Locator.Microsoft.Extensions.DependencyInjection.Interface;
using Jal.Locator.Microsoft.Extensions.DependencyInjection.Impl;

namespace Jal.Locator.Microsoft.Extensions.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static INamedServiceCollection AddServiceLocator(this IServiceCollection servicecollection)
        {
            var namedservicecollection = new NamedServiceCollection(servicecollection);

            servicecollection.AddSingleton<INamedServiceCollection, NamedServiceCollection>(x=> namedservicecollection);

            servicecollection.AddSingleton<INamedServiceProvider, NamedServiceProvider>();

            servicecollection.AddSingleton<IServiceLocator, ServiceLocator>();

            return namedservicecollection;
        }

        public static INamedServiceCollection AddTransient<TService, TImplementation>(this INamedServiceCollection namedservicecollection, string name)
            where TService : class
            where TImplementation : class, TService
        {
            namedservicecollection.AddTransient(typeof(TService), typeof(TImplementation), name);

            return namedservicecollection;
        }

        public static INamedServiceCollection AddTransient(this INamedServiceCollection namedservicecollection, Type servicetype, Type implementationtype, string name)
        {
            namedservicecollection.Add(servicetype, implementationtype, name);

            namedservicecollection.ServiceCollection.AddTransient(servicetype, implementationtype);

            return namedservicecollection;
        }

        public static INamedServiceCollection AddSingleton(this INamedServiceCollection namedservicecollection, Type servicetype, Type implementationtype, string name)
        {
            namedservicecollection.Add(servicetype, implementationtype, name);

            namedservicecollection.ServiceCollection.AddSingleton(servicetype, implementationtype);

            return namedservicecollection;
        }

        public static INamedServiceCollection AddSingleton<TService, TImplementation>(this INamedServiceCollection namedservicecollection, string name)
            where TService : class
            where TImplementation : class, TService
        {
            namedservicecollection.AddSingleton(typeof(TService), typeof(TImplementation), name);

            return namedservicecollection;
        }

        public static INamedServiceCollection AddScoped(this INamedServiceCollection namedservicecollection, Type servicetype, Type implementationtype, string name)
        {
            namedservicecollection.Add(servicetype, implementationtype, name);

            namedservicecollection.ServiceCollection.AddScoped(servicetype, implementationtype);

            return namedservicecollection;
        }

        public static INamedServiceCollection AddScoped<TService, TImplementation>(this INamedServiceCollection namedservicecollection, string name)
            where TService : class
            where TImplementation : class, TService
        {
            namedservicecollection.AddScoped(typeof(TService), typeof(TImplementation), name);

            return namedservicecollection;
        }
    }
}
