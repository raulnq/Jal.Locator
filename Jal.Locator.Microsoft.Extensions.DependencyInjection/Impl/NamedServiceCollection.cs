using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Jal.Locator.Microsoft.Extensions.DependencyInjection.Interface;

namespace Jal.Locator.Microsoft.Extensions.DependencyInjection.Impl
{
    public class NamedServiceCollection : INamedServiceCollection
    {
        private readonly IDictionary<Type, Dictionary<string, Type>> _registrations;

        public IServiceCollection ServiceCollection { get; private set; }

        public NamedServiceCollection(IServiceCollection servicecollection)
        {
            _registrations = new Dictionary<Type, Dictionary<string, Type>>();

            ServiceCollection = servicecollection;
        }

        public void Add(Type service, Type implementationtype, string name)
        {
            if (_registrations.ContainsKey(service))
            {
                _registrations[service].Add(name, implementationtype);
            }
            else
            {
                _registrations.Add(service, new Dictionary<string, Type>() { { name, implementationtype } });
            }
        }

        public Type Get(Type servicetype, string name)
        {
            if(_registrations.ContainsKey(servicetype))
            {
                var implementations = _registrations[servicetype];

                if (implementations.ContainsKey(name))
                {
                    return implementations[name];
                }
            }

            return null;
        }
    }
}
