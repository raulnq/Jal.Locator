using Jal.Locator.Impl;
using Jal.Locator.Interface;
using Jal.Locator.Interface.Fluent;

namespace Jal.Locator.Fluent
{
    public class ServiceLocatorFluentBuilder : IServiceLocatorFluentBuilder
    {      
        public IServiceLocator Create
        {
            get { return new ServiceLocator(); }
        }
    }
}