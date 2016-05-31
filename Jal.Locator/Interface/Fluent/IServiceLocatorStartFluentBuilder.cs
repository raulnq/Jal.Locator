namespace Jal.Locator.Interface.Fluent
{
    public interface IServiceLocatorStartFluentBuilder : IServiceLocatorEndFluentBuilder
    {
        IServiceLocatorEndFluentBuilder UseServiceLocator(IServiceLocator serviceLocator);
    }
}