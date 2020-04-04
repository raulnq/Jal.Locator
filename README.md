# Jal.Locator
Just another library to implement a service locator pattern

## How to use?

### Default implementation (Not recommended)

Create an instance of the locator
```c++
var locator = new ServiceLocator();
```
Register your service
```c++
locator.Register(typeof(IDoSomething), new DoSomething());
```   
Resolve your service
```c++
var service = locator.Resolve<IDoSomething>();
```
### Castle Windsor implementation

Setup the container
```c++
var container = new WindsorContainer();
```
Install the library
```c++
container.Install(new ServiceLocatorInstaller());
```
Register your service
```c++
container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>());
```			
Resolve an instance of the IServiceLocator class
```c++
var locator = container.Resolve<IServiceLocator>();
```
Resolve your service
```c++
var service = locator.Resolve<IDoSomething>();
```
### LightInject implementation

Setup the container
```c++
var container = new ServiceContainer();
```
Install the library
```c++
container.RegisterFrom<ServiceLocatorCompositionRoot>();
```
Register your service
```c++
container.Register<IDoSomething, DoSomething>();
```			
Resolve an instance of the IServiceLocator class
```c++
var locator = container.GetInstance<IServiceLocator>();
```
Resolve your service
```c++
var service = locator.Resolve<IDoSomething>();
```
### Microsoft.Extensions.DependencyInjection implementation

Setup the container
```c++
var container = new ServiceCollection();
```
Install the library
```c++
container.AddServiceLocator();
```
Register your service
```c++
container.AddSingleton<IDoSomething, DoSomething>();
```			
Resolve an instance of the IServiceLocator class
```c++
var provider = container.BuildServiceProvider()

var locator = provider.GetService<IServiceLocator>();
```
Resolve your service
```c++
var service = locator.Resolve<IDoSomething>();
```

[![Build status](https://ci.appveyor.com/api/projects/status/9iysp7cav79otj2n?svg=true)](https://ci.appveyor.com/project/raulnq/jal-locator)
[![NuGet](https://img.shields.io/nuget/v/Jal.Locator.svg)](https://www.nuget.org/packages/Jal.Locator) 
[![NuGet](https://img.shields.io/nuget/v/Jal.Locator.CastleWindsor.svg)](https://www.nuget.org/packages/Jal.Locator.CastleWindsor)
[![NuGet](https://img.shields.io/nuget/v/Jal.Locator.LightInject.svg)](https://www.nuget.org/packages/Jal.Locator.LightInject)
