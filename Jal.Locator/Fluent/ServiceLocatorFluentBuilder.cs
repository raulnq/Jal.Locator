using System;
using Jal.Locator.Impl;
using Jal.Locator.Interface;
using Jal.Locator.Interface.Fluent;

namespace Jal.Locator.Fluent
{
    public class ServiceLocatorFluentBuilder : IServiceLocatorEndFluentBuilder, IServiceLocatorStartFluentBuilder
    {

        private IServiceLocator _serviceLocator;

        public IServiceLocator Create
        {
            get
            {
                if (_serviceLocator != null)
                {
                    return _serviceLocator;
                }

                return new ServiceLocator();
            }
        }

        public IServiceLocatorEndFluentBuilder UseServiceLocator(IServiceLocator serviceLocator)
        {
            if (serviceLocator==null)
            {
                throw new ArgumentNullException("serviceLocator");
            }
            _serviceLocator = serviceLocator;

            return this;
        }
    }
}