# Jal.Locator
Just another library to implement a service locator pattern

## How to use?
Implement the interface IServiceLocator

The following example is using the Castle Windsor implementation

Setup the Castle Windsor container, use the ServiceLocatorInstaller class included

    var container = new WindsorContainer();
    container.Install(new ServiceLocatorInstaller());
	
Resolve an instance of the class IServiceLocator

    var locator = container.Resolve<IServiceLocator>();
	
Resolve your interfaces using the service locator class

    var service = locator.Resolve<IDoSomething>();