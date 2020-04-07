using Castle.Windsor;

namespace Jal.Locator.CastleWindsor
{
    public static class WindsorContainerExtensions
    {
        public static void AddServiceLocator(this IWindsorContainer container)
        {
            container.Install(new ServiceLocatorInstaller());
        }
    }
}