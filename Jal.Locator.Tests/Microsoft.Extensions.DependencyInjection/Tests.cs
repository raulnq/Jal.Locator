using Jal.Locator.Microsoft.Extensions.DependencyInjection;
using Jal.Locator.Tests.Impl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jal.Locator.Tests.Microsoft.Extensions.DependencyInjection
{
    [TestClass]
    public class Tests
    {
        private IServiceCollection _container;

        private ServiceLocatorTest _test;

        [TestInitialize]
        public void Setup()
        {
            _container = new ServiceCollection();

            _container.AddServiceLocator();

            _test = new ServiceLocatorTest();
        }

        [TestMethod]
        public void ResolveByType_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _container.AddSingleton<IDoSomething, DoSomething>();

            var provider = _container.BuildServiceProvider();

            var _sut = provider.GetService<IServiceLocator>();

            _test.ResolveByType_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut);
        }

        [TestMethod]
        public void ResolveByType_WithoutRegisteredObject_ShouldThrowException()
        {
            var provider = _container.BuildServiceProvider();

            var _sut = provider.GetService<IServiceLocator>();

            _test.ResolveByType_WithoutRegisteredObject_ShouldThrowException(_sut);
        }

        [TestMethod]
        public void Resolve_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _container.AddSingleton<IDoSomething, DoSomething>();

            var provider = _container.BuildServiceProvider();

            var _sut = provider.GetService<IServiceLocator>();

            _test.Resolve_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut);
        }

        [TestMethod]
        public void Resolve_WithoutRegisteredObject_ShouldThrowException()
        {
            var provider = _container.BuildServiceProvider();

            var _sut = provider.GetService<IServiceLocator>();

            _test.Resolve_WithoutRegisteredObject_ShouldThrowException(_sut);
        }

        [TestMethod]
        public void ResolveByKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _container.AddSingleton<IDoSomething, DoSomething>();

            var provider = _container.BuildServiceProvider();

            var _sut = provider.GetService<IServiceLocator>();

            _test.ResolveByKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut,typeof(DoSomething).FullName);
        }

        [TestMethod]
        public void ResolveByKey_WithoutRegisteredObject_ShouldThrowException()
        {
            var provider = _container.BuildServiceProvider();

            var _sut = provider.GetService<IServiceLocator>();

            _test.ResolveByKey_WithoutRegisteredObject_ShouldThrowException(_sut, "key");
        }

        [TestMethod]
        public void ResolveAll_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _container.AddSingleton<IDoSomething, DoSomething>();

            _container.AddSingleton<IDoSomething, OtherDoSomething>();

            var provider = _container.BuildServiceProvider();

            var _sut = provider.GetService<IServiceLocator>();

            _test.ResolveAll_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut);
        }
    }
}
