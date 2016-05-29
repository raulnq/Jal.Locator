using System;
using Jal.Locator.Impl;
using Jal.Locator.Tests.Impl;
using Jal.Locator.Tests.Interface;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Shouldly;

namespace Jal.Locator.Tests
{
    [TestFixture]
    public class ServiceLocatorTests
    {
        [Test]
        public void ResolveByType_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            var sut = ServiceLocator.Build.Create as ServiceLocator;

            sut.Register(typeof(IDoSomething), new DoSomething());

            var instance = sut.Resolve(typeof(IDoSomething));

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }

        [Test]
        public void ResolveByType_WithoutRegisteredObject_ShouldThrowException()
        {
            var sut = ServiceLocator.Build.Create as ServiceLocator;

            Should.Throw<Exception>(() => sut.Resolve(typeof(IDoSomething)));
        }

        [Test]
        public void Resolve_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            var sut = ServiceLocator.Build.Create as ServiceLocator;

            sut.Register(typeof(IDoSomething), new DoSomething());

            var instance = sut.Resolve<IDoSomething>();

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }

        [Test]
        public void Resolve_WithoutRegisteredObject_ShouldThrowException()
        {
            var sut = ServiceLocator.Build.Create as ServiceLocator;

            Should.Throw<Exception>(() => sut.Resolve<IDoSomething>());
        }

        [Test]
        public void ResolveByKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            var sut = ServiceLocator.Build.Create as ServiceLocator;

            sut.Register(typeof(IDoSomething), new DoSomething(), "key");

            var instance = sut.Resolve<IDoSomething>("key");

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }

        [Test]
        public void ResolveByKey_WithoutRegisteredObject_ShouldThrowException()
        {
            var sut = ServiceLocator.Build.Create as ServiceLocator;

            Should.Throw<Exception>(() => sut.Resolve<IDoSomething>("key"));
        }

        [Test]
        public void ResolveAll_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            var sut = ServiceLocator.Build.Create as ServiceLocator;

            sut.Register(typeof(IDoSomething), new DoSomething());

            var instance = sut.ResolveAll<IDoSomething>();

            instance.ShouldBeAssignableTo(typeof(IDoSomething[]));
        }

        [Test]
        public void ResolveByTypeAndKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            var sut = ServiceLocator.Build.Create as ServiceLocator;

            var o = new DoSomething();

            sut.Register(typeof(IDoSomething), o, "key");

            var instance = sut.Resolve(typeof(IDoSomething), "key");

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }
    }
}
