using Jal.Locator.Impl;
using Jal.Locator.Tests.Impl;
using Jal.Locator.Tests.Interface;
using NUnit.Framework;

namespace Jal.Locator.Tests.Default
{
    [TestFixture]
    public class Tests
    {
        private ServiceLocator _sut;

        private ServiceLocatorTest _test;

        [SetUp]
        public void Setup()
        {
            _sut = new ServiceLocator();

            _test = new ServiceLocatorTest();
        }

        [Test]
        public void ResolveByType_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            _sut.Register(typeof(IDoSomething), new DoSomething());

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
            _sut.Register(typeof(IDoSomething), new DoSomething());

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
            _sut.Register(typeof(IDoSomething), new DoSomething(), "key");

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
            _sut.Register(typeof(IDoSomething), new DoSomething());

            _test.ResolveAll_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut);
        }

        [Test]
        public void ResolveByTypeAndKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {

            _sut.Register(typeof(IDoSomething), new DoSomething(), "key");

            _test.ResolveByTypeAndKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething(_sut, "key");
        }

        [Test]
        public void ResolveByTypeAndKey_WithRegisterdObject_ShouldThrowException()
        {
            _test.ResolveByTypeAndKey_WithRegisterdObject_ShouldThrowException(_sut, "key");
        }
    }
}
