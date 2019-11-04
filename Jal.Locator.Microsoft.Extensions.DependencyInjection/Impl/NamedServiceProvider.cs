using System;
using System.Linq;
using Jal.Locator.Microsoft.Extensions.DependencyInjection.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Jal.Locator.Microsoft.Extensions.DependencyInjection.Impl
{
    internal class NamedServiceProvider : INamedServiceProvider
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly INamedServiceCollection _namedservicecollection;

        public NamedServiceProvider(IServiceProvider serviceProvider, INamedServiceCollection namedservicecollection)
        {
            _serviceProvider = serviceProvider;

            _namedservicecollection = namedservicecollection;
        }


        public object GetService(Type servicetype, string name)
        {
            var type = _namedservicecollection.Get(servicetype, name);

            if (type != null)
            {
                var implementarions = _serviceProvider.GetServices(servicetype);

                return implementarions.FirstOrDefault(x=> x.GetType()==type);
            }
            else
            {
                throw new ArgumentException($"No implementation is registered for service {servicetype} and name {name}");
            }
        }
    }
}
