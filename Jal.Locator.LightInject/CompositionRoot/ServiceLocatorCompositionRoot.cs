using LightInject;

namespace Jal.Locator.LightInject
{
    public class ServiceLocatorCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IScopedServiceLocator>(f => new ServiceLocator(f) ,new PerContainerLifetime());
            serviceRegistry.Register<IServiceLocator>(f => f.GetInstance<IScopedServiceLocator>());
        }
    }
}
