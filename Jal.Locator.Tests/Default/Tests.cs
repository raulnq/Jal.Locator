using Jal.Locator.Tests.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Jal.Locator.Tests.Default
{
    [TestClass]
    public class Tests
    {
        private ServiceLocator _sut;

        private ServiceLocatorTest _test;

        [TestInitialize]
        public void Setup()
        {
            _sut = new ServiceLocator();

            _test = new ServiceLocatorTest();
        }

        [TestMethod]
        public void ResolveByType_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _sut.Register(typeof(IDoSomething), new DoSomething());

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
            _sut.Register(typeof(IDoSomething), new DoSomething());

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
            _sut.Register(typeof(IDoSomething), new DoSomething(), "key");

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
            _sut.Register(typeof(IDoSomething), new DoSomething());

            _test.ResolveAll_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut);
        }

        [TestMethod]
        public void ResolveByTypeAndKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {

            _sut.Register(typeof(IDoSomething), new DoSomething(), "key");

            _test.ResolveByTypeAndKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut, "key");
        }

        [TestMethod]
        public void ResolveByTypeAndKey_WithRegisterdObject_ShouldThrowException()
        {
            _test.ResolveByTypeAndKey_WithRegisterdObject_ShouldThrowException(_sut, "key");
        }
    }
}
