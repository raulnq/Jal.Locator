# Jal.Locator [![Build status](https://ci.appveyor.com/api/projects/status/9iysp7cav79otj2n?svg=true)](https://ci.appveyor.com/project/raulnq/jal-locator) [![NuGet](https://img.shields.io/nuget/v/Jal.Locator.svg)](https://www.nuget.org/packages/Jal.Locator) 
Just another library to implement a service locator pattern

## How to use?

### Castle Windsor [![NuGet](https://img.shields.io/nuget/v/Jal.Locator.CastleWindsor.svg)](https://www.nuget.org/packages/Jal.Locator.CastleWindsor)

Setup the container
```csharp
var container = new WindsorContainer();
```
Install the library
```csharp
container.AddServiceLocator();
```
Register your service
```csharp
container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>());
```			
Resolve an instance of the IServiceLocator class
```csharp
var locator = container.Resolve<IServiceLocator>();
```
Resolve your service
```csharp
var service = locator.Resolve<IDoSomething>();
```
### LightInject [![NuGet](https://img.shields.io/nuget/v/Jal.Locator.LightInject.svg)](https://www.nuget.org/packages/Jal.Locator.LightInject)

Setup the container
```csharp
var container = new ServiceContainer();
```
Install the library
```csharp
container.AddServiceLocator();
```
Register your service
```csharp
container.Register<IDoSomething, DoSomething>();
```			
Resolve an instance of the IServiceLocator class
```csharp
var locator = container.GetInstance<IServiceLocator>();
```
Resolve your service
```csharp
var service = locator.Resolve<IDoSomething>();
```
### Microsoft.Extensions.DependencyInjection [![NuGet](https://img.shields.io/nuget/v/Jal.Locator.Microsoft.Extensions.DependencyInjection.svg)](https://www.nuget.org/packages/Jal.Locator.Microsoft.Extensions.DependencyInjection)

Setup the container
```csharp
var container = new ServiceCollection();
```
Install the library
```csharp
container.AddServiceLocator();
```
Register your service
```csharp
container.AddSingleton<IDoSomething, DoSomething>();
```			
Resolve an instance of the IServiceLocator class
```csharp
var provider = container.BuildServiceProvider()

var locator = provider.GetService<IServiceLocator>();
```
Resolve your service
```csharp
var service = locator.Resolve<IDoSomething>();
```




