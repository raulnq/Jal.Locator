using System;

namespace Jal.Locator
{
    public interface IScopedServiceLocator : IServiceLocator
    {
        IDisposable BeginScope();
    }
}
