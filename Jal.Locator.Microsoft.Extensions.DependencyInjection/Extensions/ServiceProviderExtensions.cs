using System;
using Microsoft.Extensions.DependencyInjection;

namespace Jal.Locator.Microsoft.Extensions.DependencyInjection
{
    public static class ServiceProviderExtensions
    {
        public static IServiceLocator GetServiceLocator(this IServiceProvider provider)
        {
            return provider.GetService<IServiceLocator>();
        }
    }
}
