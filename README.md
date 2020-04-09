# Jal.Locator [![Build status](https://ci.appveyor.com/api/projects/status/9iysp7cav79otj2n?svg=true)](https://ci.appveyor.com/project/raulnq/jal-locator) [![NuGet](https://img.shields.io/nuget/v/Jal.Locator.svg)](https://www.nuget.org/packages/Jal.Locator) 
Just another library to implement a service locator pattern

## How to use?

### Castle Windsor [![NuGet](https://img.shields.io/nuget/v/Jal.Locator.CastleWindsor.svg)](https://www.nuget.org/packages/Jal.Locator.CastleWindsor)
```csharp
var container = new WindsorContainer();

container.AddServiceLocator();

container.Register(Component.For<IDoSomething>().ImplementedBy<DoSomething>());

var locator = container.GetServiceLocator();

var service = locator.Resolve<IDoSomething>();
```
### LightInject [![NuGet](https://img.shields.io/nuget/v/Jal.Locator.LightInject.svg)](https://www.nuget.org/packages/Jal.Locator.LightInject)

```csharp
var container = new ServiceContainer();

container.AddServiceLocator();

container.Register<IDoSomething, DoSomething>();

var locator = container.GetServiceLocator();

var service = locator.Resolve<IDoSomething>();
```
### Microsoft.Extensions.DependencyInjection [![NuGet](https://img.shields.io/nuget/v/Jal.Locator.Microsoft.Extensions.DependencyInjection.svg)](https://www.nuget.org/packages/Jal.Locator.Microsoft.Extensions.DependencyInjection)
```csharp
var container = new ServiceCollection();

container.AddServiceLocator();

container.AddSingleton<IDoSomething, DoSomething>();

var provider = container.BuildServiceProvider()

var locator = provider.GetServiceLocator();

var service = locator.Resolve<IDoSomething>();
```
