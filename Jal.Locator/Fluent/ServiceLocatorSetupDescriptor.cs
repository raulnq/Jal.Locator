using Jal.Locator.Interface;

namespace Jal.Locator.Impl
{
    public class ServiceLocatorSetupDescriptor
    {
        public IServiceLocator Create()
        {
            return new ServiceLocator();
        }
    }
}