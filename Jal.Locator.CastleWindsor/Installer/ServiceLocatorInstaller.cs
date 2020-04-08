using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Jal.Locator.CastleWindsor
{

    public class ServiceLocatorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if(!container.Kernel.HasComponent(typeof(IServiceLocator)))
            {
                container.Register(Component.For<IServiceLocator, IScopedServiceLocator>().ImplementedBy<ServiceLocator>().DependsOn(new { Container = container }).LifestyleSingleton());
            }
        }
    }
}