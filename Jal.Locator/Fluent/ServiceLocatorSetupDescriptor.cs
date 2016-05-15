using Jal.Locator.Impl;
using Jal.Locator.Interface;

namespace Jal.Locator.Fluent
{
    public class ServiceLocatorSetupDescriptor
    {
        public IServiceLocator Create()
        {
            return new ServiceLocator();
        }
    }
}