using System;
using Shouldly;

namespace Jal.Locator.Tests.Impl
{
    public class ServiceLocatorTest
    {
        public void ResolveByType_WithRegisterdObject_ShouldBeAssignableToIDoSomething(Locator.IServiceLocator sut)
        {
            var instance = sut.Resolve(typeof(IDoSomething));

            instance.ShouldNotBeNull();

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }

        public void ResolveByType_WithoutRegisteredObject_ShouldThrowException(Locator.IServiceLocator sut)
        {
            Should.Throw<Exception>(() => sut.Resolve(typeof(IDoSomething)));
        }

        public void Resolve_WithRegisterdObject_ShouldBeAssignableToIDoSomething(Locator.IServiceLocator sut)
        {
            var instance = sut.Resolve<IDoSomething>();

            instance.ShouldNotBeNull();

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }

        public void Resolve_WithoutRegisteredObject_ShouldThrowException(Locator.IServiceLocator sut)
        {
            Should.Throw<Exception>(() => sut.Resolve<IDoSomething>());
        }

        public void ResolveByKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething(Locator.IServiceLocator sut, string key)
        {
            var instance = sut.Resolve<IDoSomething>(key);

            instance.ShouldNotBeNull();

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }

        public void ResolveByKey_WithoutRegisteredObject_ShouldThrowException(Locator.IServiceLocator sut, string key)
        {
            Should.Throw<Exception>(() => sut.Resolve<IDoSomething>(key));
        }

        public void ResolveAll_WithRegisterdObject_ShouldBeAssignableToIDoSomething(Locator.IServiceLocator sut)
        {
            var instance = sut.ResolveAll<IDoSomething>();

            instance.ShouldNotBeNull();

            instance.ShouldBeAssignableTo(typeof(IDoSomething[]));
        }

        public void ResolveByTypeAndKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething(Locator.IServiceLocator sut, string key)
        {
            var instance = sut.Resolve(typeof(IDoSomething), key);

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }

        public void ResolveByTypeAndKey_WithRegisterdObject_ShouldThrowException(Locator.IServiceLocator sut, string key)
        {
            Should.Throw<Exception>(() => sut.Resolve(typeof(IDoSomething), key));
        }

        public void BeginScopeRelease_WithRegisterdObject_ShouldBeAssignableToIDoSomething(Locator.IScopedServiceLocator sut)
        {
            using (sut.BeginScope())
            {
                var instance1 = sut.Resolve<IDoSomething>();

                var instance2 = sut.Resolve<IDoSomething>();

                instance1.ShouldBeAssignableTo(typeof(IDoSomething));

                instance2.ShouldBeAssignableTo(typeof(IDoSomething));

                instance1.ShouldBeSameAs(instance2);
            }
        }
    }
}