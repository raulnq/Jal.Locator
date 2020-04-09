using LightInject;

namespace Jal.Locator.LightInject
{
    public static class ServiceContainerExtension
    {
        public static void AddServiceLocator(this IServiceContainer container)
        {
            container.RegisterFrom<ServiceLocatorCompositionRoot>();
        }

        public static IServiceLocator GetServiceLocator(this IServiceContainer container)
        {
            return container.GetInstance<IServiceLocator>();
        }

       
    }
}
