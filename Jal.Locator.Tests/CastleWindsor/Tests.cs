using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Jal.Locator.CastleWindsor;
using Jal.Locator.Tests.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jal.Locator.Tests.CastleWindsor
{
    [TestClass]
    public class Tests
    {
        private WindsorContainer _container;

        private IServiceLocator _sut;

        private ServiceLocatorTest _test;

        [TestInitialize]
        public void Setup()
        {
            _container = new WindsorContainer();

            _container.AddServiceLocator();

            _sut = _container.Resolve<IServiceLocator>();

            _test = new ServiceLocatorTest();
        }

        [TestMethod]
        public void ResolveByType_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().LifestyleSingleton());

            _test.ResolveByType_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut);
        }

        [TestMethod]
        public void ResolveByType_WithoutRegisteredObject_ShouldThrowException()
        {
            _test.ResolveByType_WithoutRegisteredObject_ShouldThrowException(_sut);
        }

        [TestMethod]
        public void Resolve_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().LifestyleSingleton());

            _test.Resolve_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut);
        }

        [TestMethod]
        public void Resolve_WithoutRegisteredObject_ShouldThrowException()
        {
            _test.Resolve_WithoutRegisteredObject_ShouldThrowException(_sut);
        }

        [TestMethod]
        public void ResolveByKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().LifestyleSingleton().Named("key"));

            _test.ResolveByKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut, "key");
        }

        [TestMethod]
        public void ResolveByKey_WithoutRegisteredObject_ShouldThrowException()
        {
            _test.ResolveByKey_WithoutRegisteredObject_ShouldThrowException(_sut, "key");
        }

        [TestMethod]
        public void ResolveAll_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().LifestyleSingleton());

            _test.ResolveAll_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut);
        }

        [TestMethod]
        public void BeginScopeRelease_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().LifestyleScoped());

            var sut = _container.Resolve<IScopedServiceLocator>();

            _test.BeginScopeRelease_WithRegisterdObject_ShouldBeAssignableToIDoSomething(sut);
        }

        [TestMethod]
        public void ResolveByTypeAndKey_WithRegisteredObject_ShouldBeAssignableToIDoSomething()
        {
            _container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().Named(typeof(DoSomething).Name).LifestyleSingleton());

            _test.ResolveByTypeAndKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut, typeof(DoSomething).Name);
        }

        [TestMethod]
        public void ResolveByTypeAndKey_WithRegisterdObject_ShouldThrowException()
        {
            _test.ResolveByTypeAndKey_WithRegisterdObject_ShouldThrowException(_sut, "key");
        }
    }
}
