using System;
using System.Collections.Generic;
using UnityEngine;

namespace UIFramework.Utilities
{
    // Implementation of the Service Locator design pattern.
    public class ServiceLocator
    {
        private Dictionary<Type, MonoBehaviour> services;

        public ServiceLocator()
        {
            services = new Dictionary<Type, MonoBehaviour>();
        }

        public T Get<T>() where T : MonoBehaviour, new()
        {
            bool serviceLocated = services.ContainsKey(typeof(T));
            if (!serviceLocated)
                services.Add(typeof(T), GameObject.FindObjectOfType<T>());

            UnityEngine.Assertions.Assert.IsTrue(services.ContainsKey
                (typeof(T)), $"Could not find service {typeof(T)}.");

            T service = (T)services[typeof(T)];

            UnityEngine.Assertions.Assert.IsNotNull(service,
                $"Service '{typeof(T)}' in Scene '" +
                $"{UnityEngine.SceneManagement.SceneManager.GetActiveScene().name}' could not be found.");

            return service;
        }

        public static bool operator !(ServiceLocator serviceLocator) { return serviceLocator == null; }
    }
}