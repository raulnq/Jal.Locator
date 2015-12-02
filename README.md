# Jal.Locator
Just another library to implement a service locator pattern

## How to use?
Implement the interface IServiceLocator (The following example is using the Castle Windsor implementation included)

Setup the Castle Windsor container

    var container = new WindsorContainer();
	
Install the Jal.Locator library, use the ServiceLocatorInstaller class included

    container.Install(new ServiceLocatorInstaller());
	
Register your services

	container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().LifestyleSingleton());
				
Resolve an instance of the IServiceLocator class

    var locator = container.Resolve<IServiceLocator>();
	
Resolve your interfaces using the service locator class

    var service = locator.Resolve<IDoSomething>();
