using System;
using Microsoft.Extensions.DependencyInjection;

namespace Jal.Locator.Microsoft.Extensions.DependencyInjection.Interface
{
    public interface INamedServiceCollection
    {
        Type Get(Type servicetype, string name);

        void Add(Type servicetype, Type implementationtype, string name);

        IServiceCollection ServiceCollection { get;}
    }
}
