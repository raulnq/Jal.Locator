using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Jal.Locator.CastleWindsor.Installer;
using Jal.Locator.Interface;
using Jal.Locator.Tests.Impl;
using Jal.Locator.Tests.Interface;
using NUnit.Framework;

namespace Jal.Locator.Tests.CastleWindsor
{
    [TestFixture]
    public class Tests
    {
        private WindsorContainer _container;

        private IServiceLocator _sut;

        private ServiceLocatorTest _test;

        [SetUp]
        public void Setup()
        {
            _container = new WindsorContainer();

            _container.Install(new ServiceLocatorInstaller());

            _sut = _container.Resolve<IServiceLocator>();

            _test = new ServiceLocatorTest();
        }

        [Test]
        public void ResolveByType_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().LifestyleSingleton());

            _test.ResolveByType_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut);
        }

        [Test]
        public void ResolveByType_WithoutRegisteredObject_ShouldThrowException()
        {
            _test.ResolveByType_WithoutRegisteredObject_ShouldThrowException(_sut);
        }

        [Test]
        public void Resolve_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().LifestyleSingleton());

            _test.Resolve_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut);
        }

        [Test]
        public void Resolve_WithoutRegisteredObject_ShouldThrowException()
        {
            _test.Resolve_WithoutRegisteredObject_ShouldThrowException(_sut);
        }

        [Test]
        public void ResolveByKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().LifestyleSingleton().Named("key"));

            _test.ResolveByKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut, "key");
        }

        [Test]
        public void ResolveByKey_WithoutRegisteredObject_ShouldThrowException()
        {
            _test.ResolveByKey_WithoutRegisteredObject_ShouldThrowException(_sut, "key");
        }

        [Test]
        public void ResolveAll_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().LifestyleSingleton());

            _test.ResolveAll_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut);
        }

        [Test]
        public void BeginScopeRelease_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().LifestyleScoped());

            var sut = _container.Resolve<IScopedServiceLocator>();

            _test.BeginScopeRelease_WithRegisterdObject_ShouldBeAssignableToIDoSomething(sut);
        }

        [Test]
        public void ResolveByTypeAndKey_WithRegisteredObject_ShouldBeAssignableToIDoSomething()
        {
            _container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().Named(typeof(DoSomething).Name).LifestyleSingleton());

            _test.ResolveByTypeAndKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut, "key");
        }

        [Test]
        public void ResolveByTypeAndKey_WithRegisterdObject_ShouldThrowException()
        {
            _test.ResolveByTypeAndKey_WithRegisterdObject_ShouldThrowException(_sut, "key");
        }
    }
}
