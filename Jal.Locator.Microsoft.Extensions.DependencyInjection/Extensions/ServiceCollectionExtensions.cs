using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Jal.Locator.Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceLocator(this IServiceCollection servicecollection)
        {
            servicecollection.TryAddSingleton<ServiceLocator>();

            servicecollection.TryAddSingleton<IServiceLocator>(x => x.GetRequiredService<ServiceLocator>());

            servicecollection.TryAddSingleton<IScopedServiceLocator>(x => x.GetRequiredService<ServiceLocator>());

            return servicecollection;
        }
    }
}
