# Jal.Locator
Just another library to implement a service locator pattern

## How to use?

### Default implementation

I only suggest to use this implementation on simple apps.

Create an instance of the locator

    var locator = ServiceLocator.Build.Create as ServiceLocator;

Register your service

    locator.Register(typeof(IDoSomething), new DoSomething());
    
Resolve your service

    var service = locator.Resolve<IDoSomething>();

### Castle Windsor implementation

The following example is using the Castle Windsor implementation

Setup the container

    var container = new WindsorContainer();
	
Install the library

    container.Install(new ServiceLocatorInstaller());
	
Register your service

	container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>().LifestyleSingleton());
				
Resolve an instance of the IServiceLocator class

    var locator = container.Resolve<IServiceLocator>();
	
Resolve your service

    var service = locator.Resolve<IDoSomething>();

[![Build status](https://ci.appveyor.com/api/projects/status/9iysp7cav79otj2n?svg=true)](https://ci.appveyor.com/project/raulnq/jal-locator)
[![NuGet](https://img.shields.io/nuget/dt/Jal.Locator.svg)](https://www.nuget.org/packages/Jal.Locator) 
[![NuGet](https://img.shields.io/nuget/vpre/Jal.Locator.svg)](https://www.nuget.org/packages/Jal.Locator)
