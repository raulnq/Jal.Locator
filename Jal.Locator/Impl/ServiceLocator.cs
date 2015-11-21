using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Jal.Locator.Interface;

namespace Jal.Locator.Impl
{
    [DebuggerDisplay("Items: {_objects.Keys.Count}")]
    public class ServiceLocator : IServiceLocator
    {
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        private readonly Dictionary<string, object> _objects;

        public void Register(object instance)
        {
            _objects.Add(instance.GetType().FullName, instance);
        }

        public ServiceLocator()
        {
            _objects = new Dictionary<string, object>();
        }

        public TSource Resolve<TSource>() where TSource : class
        {
            foreach (var o in _objects.Where(o => o.Value is TSource))
            {
                return o.Value as TSource;
            }
            throw new ArgumentException(string.Format("It is not posible to get a instance of {0}", typeof(TSource).Name));
        }

        public TSource Resolve<TSource>(string key) where TSource : class
        {
            return _objects[key] as TSource;
        }

        public TSource[] ResolveAll<TSource>() where TSource : class
        {
            return _objects.Where(o => o.Value is TSource).Select(x => x.Value as TSource).ToArray();
        }

        public object Resolve(Type service)
        {
            foreach (var o in _objects.Where(o => service.IsInstanceOfType(o.Value)))
            {
                return o.Value;
            }
            throw new ArgumentException(string.Format("It is not posible to get a instance of {0}", service.Name));
        }
    }
}