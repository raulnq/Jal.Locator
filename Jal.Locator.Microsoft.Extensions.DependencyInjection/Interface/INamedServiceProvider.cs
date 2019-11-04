using System;

namespace Jal.Locator.Microsoft.Extensions.DependencyInjection.Interface
{
    public interface INamedServiceProvider
    {
        object GetService(Type service, string name);
    }
}
