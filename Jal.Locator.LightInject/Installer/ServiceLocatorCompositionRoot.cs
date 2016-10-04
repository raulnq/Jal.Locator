using Jal.Locator.Interface;
using Jal.Locator.LightInject.Impl;
using LightInject;

namespace Jal.Locator.LightInject.Installer
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
