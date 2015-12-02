using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Jal.Locator.CastleWindsor.Installer;
using Jal.Locator.Interface;
using Jal.Locator.Tests.Impl;
using Jal.Locator.Tests.Interface;
using NUnit.Framework;
using Shouldly;

namespace Jal.Locator.Tests.CastleWindsor
{
    [TestFixture]
    public class ServiceLocatorTests
    {

        [Test]
        public void ResolveByType_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            var container = new WindsorContainer();

            container.Install(new ServiceLocatorInstaller());

            container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().LifestyleSingleton());

            var sut = container.Resolve<IServiceLocator>();

            var instance = sut.Resolve(typeof(IDoSomething));

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }

        [Test]
        public void ResolveByType_WithoutRegisteredObject_ShouldThrowException()
        {
            var container = new WindsorContainer();

            container.Install(new ServiceLocatorInstaller());

            var sut = container.Resolve<IServiceLocator>();

            Should.Throw<Exception>(() => sut.Resolve(typeof(IDoSomething)));
        }

        [Test]
        public void Resolve_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            var container = new WindsorContainer();

            container.Install(new ServiceLocatorInstaller());

            container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().LifestyleSingleton());

            var sut = container.Resolve<IServiceLocator>();

            var instance = sut.Resolve<IDoSomething>();

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }

        [Test]
        public void Resolve_WithoutRegisteredObject_ShouldThrowException()
        {
            var container = new WindsorContainer();

            container.Install(new ServiceLocatorInstaller());

            var sut = container.Resolve<IServiceLocator>();

            Should.Throw<Exception>(() => sut.Resolve<IDoSomething>());
        }

        [Test]
        public void ResolveByKey_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            var container = new WindsorContainer();

            container.Install(new ServiceLocatorInstaller());

            container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().LifestyleSingleton().Named(typeof(DoSomething).Name));

            var sut = container.Resolve<IServiceLocator>();

            var instance = sut.Resolve<IDoSomething>(typeof(DoSomething).Name);

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }

        [Test]
        public void ResolveByKey_WithoutRegisteredObject_ShouldThrowException()
        {
            var container = new WindsorContainer();

            container.Install(new ServiceLocatorInstaller());

            var sut = container.Resolve<IServiceLocator>();

            Should.Throw<Exception>(() => sut.Resolve<IDoSomething>(typeof(DoSomething).Name));
        }

        [Test]
        public void ResolveAll_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            var container = new WindsorContainer();

            container.Install(new ServiceLocatorInstaller());

            var sut = container.Resolve<IServiceLocator>();

            var instance = sut.ResolveAll<IDoSomething>();

            instance.ShouldBeAssignableTo(typeof(IDoSomething[]));
        }

        [Test]
        public void BeginScopeRelease_WithRegisterdObject_ShouldBeAssignableToIDoSomething()
        {
            var container = new WindsorContainer();

            container.Install(new ServiceLocatorInstaller());

            container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().LifestyleScoped());

            var sut = container.Resolve<IScopedServiceLocator>();

            using (sut.BeginScope())
            {
                var instance = sut.Resolve<IDoSomething>();

                instance.ShouldBeAssignableTo(typeof(IDoSomething));

                sut.Release(instance);
            }  
        }

        [Test]
        public void ResolveByTypeAndKey_WithRegisteredObject_ShouldBeAssignableToIDoSomething()
        {
            var container = new WindsorContainer();

            container.Install(new ServiceLocatorInstaller());

            container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().Named(typeof(DoSomething).Name).LifestyleSingleton());

            var sut = container.Resolve<IServiceLocator>();

            var instance = sut.Resolve(typeof(IDoSomething), typeof(DoSomething).Name);

            instance.ShouldBeAssignableTo(typeof(IDoSomething));
        }
    }
}
