using System;

namespace Jal.Locator.Interface
{
    public interface IScopedServiceLocator : IServiceLocator
    {
        IDisposable BeginScope();

        void Release(object instance);
    }
}
