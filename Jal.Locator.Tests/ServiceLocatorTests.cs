using System;
using Jal.Locator.Impl;
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
            var fixture = new Fixture();

            var sut = fixture.Create<ServiceLocator>();

            sut.Register(typeof(IDoSomething), fixture.Create<Mock<IDoSomething>>().Object);

            var instance = sut.Resolve(typeof(IDoSomething));

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }

        [Test]
        public void ResolveByType_WithoutRegisteredObject_ShouldThrowException()
        {
            var fixture = new Fixture();

            var sut = fixture.Create<ServiceLocator>();

            Should.Throw<Exception>(() => sut.Resolve(typeof(IDoSomething)));
        }

        [Test]
        public void Resolve_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            var fixture = new Fixture();

            var sut = fixture.Create<ServiceLocator>();

            sut.Register(typeof(IDoSomething), fixture.Create<Mock<IDoSomething>>().Object);

            var instance = sut.Resolve<IDoSomething>();

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }

        [Test]
        public void Resolve_WithoutRegisteredObject_ShouldThrowException()
        {
            var fixture = new Fixture();

            var sut = fixture.Create<ServiceLocator>();

            Should.Throw<Exception>(() => sut.Resolve<IDoSomething>());
        }

        [Test]
        public void ResolveByKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            var fixture = new Fixture();

            var sut = fixture.Create<ServiceLocator>();

            var service = fixture.Create<Mock<IDoSomething>>().Object;

            sut.Register(typeof(IDoSomething), service, "key");

            var instance = sut.Resolve<IDoSomething>("key");

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }

        [Test]
        public void ResolveByKey_WithoutRegisteredObject_ShouldThrowException()
        {
            var fixture = new Fixture();

            var sut = fixture.Create<ServiceLocator>();

            var service = fixture.Create<Mock<IDoSomething>>().Object;

            Should.Throw<Exception>(() => sut.Resolve<IDoSomething>(service.GetType().Name));
        }

        [Test]
        public void ResolveAll_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            var fixture = new Fixture();

            var sut = fixture.Create<ServiceLocator>();

            sut.Register(typeof(IDoSomething), fixture.Create<Mock<IDoSomething>>().Object);

            var instance = sut.ResolveAll<IDoSomething>();

            instance.ShouldBeAssignableTo(typeof(IDoSomething[]));
        }

        [Test]
        public void ResolveByTypeAndKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            var fixture = new Fixture();

            var sut = fixture.Create<ServiceLocator>();

            var o = fixture.Create<Mock<IDoSomething>>().Object;

            sut.Register(typeof(IDoSomething), o, "key");

            var instance = sut.Resolve(typeof(IDoSomething), "key");

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }
    }
}
