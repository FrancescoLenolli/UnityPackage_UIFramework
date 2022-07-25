using System;
using System.Collections.Generic;
using UnityEngine;

// Implementation of the Service Locator design pattern.
public static class ServiceLocator
{
    private static Dictionary<Type, MonoBehaviour> services;

    public static T Get<T>() where T : MonoBehaviour, new()
    {
        if (services == null)
            services = new Dictionary<Type, MonoBehaviour>();

        bool serviceLocated = services.ContainsKey(typeof(T));
        if (!serviceLocated)
            services.Add(typeof(T), GameObject.FindObjectOfType<T>());

        UnityEngine.Assertions.Assert.IsTrue(services.ContainsKey
            (typeof(T)), $"Could not find service {typeof(T)}.");

        var service = (T)services[typeof(T)];

        UnityEngine.Assertions.Assert.IsNotNull(service,
            $"Service '{typeof(T)}' in Scene '" +
            $"{UnityEngine.SceneManagement.SceneManager.GetActiveScene().name}' could not be found.");

        return service;
    }
}
