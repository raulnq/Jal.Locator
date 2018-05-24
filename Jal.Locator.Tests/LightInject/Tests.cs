using Jal.Locator.Interface;
using Jal.Locator.LightInject.Installer;
using Jal.Locator.Tests.Impl;
using Jal.Locator.Tests.Interface;
using LightInject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jal.Locator.Tests.LightInject
{
    [TestClass]
    public class Tests
    {
        private ServiceContainer _container;

        private IServiceLocator _sut;

        private ServiceLocatorTest _test;

        [TestInitialize]
        public void Setup()
        {
            _container = new ServiceContainer();

            _container.RegisterFrom<ServiceLocatorCompositionRoot>();

            _sut = _container.GetInstance<IServiceLocator>();

            _test = new ServiceLocatorTest();
        }

        [TestMethod]
        public void ResolveByType_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _container.Register<IDoSomething, DoSomething>();

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

            _container.Register<IDoSomething, DoSomething>();

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
            _container.Register<IDoSomething, DoSomething>("key");

            _test.ResolveByKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut,"key");
        }

        [TestMethod]
        public void ResolveByKey_WithoutRegisteredObject_ShouldThrowException()
        {
            _test.ResolveByKey_WithoutRegisteredObject_ShouldThrowException(_sut, "key");
        }

        [TestMethod]
        public void ResolveAll_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _container.Register<IDoSomething, DoSomething>();

            _test.ResolveAll_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut);
        }

        [TestMethod]
        public void BeginScopeRelease_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _container.Register<IDoSomething, DoSomething>(new PerContainerLifetime());

            var sut = _container.GetInstance<IScopedServiceLocator>();

            _test.BeginScopeRelease_WithRegisterdObject_ShouldBeAssignableToIDoSomething(sut);
        }

        [TestMethod]
        public void ResolveByTypeAndKey_WithRegisteredObject_ShouldBeAssignableToIDoSomething()
        {
            _container.Register<IDoSomething, DoSomething>("key");

            _test.ResolveByTypeAndKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut, "key");
        }

        [TestMethod]
        public void ResolveByTypeAndKey_WithRegisterdObject_ShouldThrowException()
        {
            _test.ResolveByTypeAndKey_WithRegisterdObject_ShouldThrowException(_sut, "key");
        }
    }
}
