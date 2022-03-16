using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Implementation of the Service Locator design pattern.
 * It's not a static or singleton class because it's designed to be utilised by another class
 * to get only the references it needs.
 * Example: Player class only needs a reference to GameManager and UIState only needs access to a UIManager,
 * and they each use a local ServiceLocator.
 * Don't know if it's a sound design decision yet, I need more research.
 */
public class ServiceLocator
{
    private Dictionary<Type, MonoBehaviour> serviceReferences;

    public ServiceLocator()
    {
        serviceReferences = new Dictionary<Type, MonoBehaviour>();
    }

    public T GetService<T>() where T: MonoBehaviour, new()
    {
        UnityEngine.Assertions.Assert.IsNotNull(serviceReferences,
            "someone has requested a service prior to the locator's initialisation.");

        bool serviceLocated = serviceReferences.ContainsKey(typeof(T));
        if (!serviceLocated)
            serviceReferences.Add(typeof(T), GameObject.FindObjectOfType<T>());

        UnityEngine.Assertions.Assert.IsTrue(serviceReferences.ContainsKey(typeof(T)), $"Could not find service {typeof(T)}.");
        var service = (T)serviceReferences[typeof(T)];
        UnityEngine.Assertions.Assert.IsNotNull(service,
            $"Service {typeof(T)} in Scene {UnityEngine.SceneManagement.SceneManager.GetActiveScene().name} could not be found.");

        return service;
    }
}
