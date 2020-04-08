using LightInject;
using System.Linq;

namespace Jal.Locator.LightInject
{
    public class ServiceLocatorCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            if(serviceRegistry.AvailableServices.All(x=>x.ServiceType!=typeof(IScopedServiceLocator)))
            {
                serviceRegistry.Register<IScopedServiceLocator>(f => new ServiceLocator(f), new PerContainerLifetime());
            }
            if (serviceRegistry.AvailableServices.All(x => x.ServiceType != typeof(IServiceLocator)))
            {
                serviceRegistry.Register<IServiceLocator>(f => f.GetInstance<IScopedServiceLocator>());
            }
        }
    }
}
