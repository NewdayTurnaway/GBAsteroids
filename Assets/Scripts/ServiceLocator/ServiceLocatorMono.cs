using System.Collections.Generic;
using UnityEngine;

namespace GBAsteroids
{
    public static class ServiceLocatorMono
    {
        private static readonly Dictionary<object, object> _serviceContainer;

        static ServiceLocatorMono()
        {
            _serviceContainer = new();
        }

        public static T FindService<T>(bool createObjectNotFound = true) where T : Object
        {
            T type = Object.FindObjectOfType<T>();

            if (type != null)
            {
                _serviceContainer.Add(typeof(T), type);
            }
            else if (createObjectNotFound)
            {
                GameObject gameObject = new(typeof(T).Name, typeof(T));
                _serviceContainer.Add(typeof(T), gameObject.GetComponent<T>());
            }

            return (T)_serviceContainer[typeof(T)];
        }

        public static T GetService<T>(bool createObjectNotFound = true) where T : Object
        {
            if (!_serviceContainer.ContainsKey(typeof(T)))
            {
                return FindService<T>(createObjectNotFound);
            }

            T service = (T)_serviceContainer[typeof(T)];
            if (service != null)
            {
                return service;
            }

            return FindService<T>(createObjectNotFound);
        }
    }
}