using System;

namespace Jal.Locator.Model
{
    public class ServiceLocatorRecord
    {
        public Type Component { get; set; }

        public object Implementation { get; set; }

        public string Name { get; set; }

        public ServiceLocatorRecord(Type component, object implementation, string name)
        {
            Component = component;
            Implementation = implementation;
            Name = name;
        }
    }
}
