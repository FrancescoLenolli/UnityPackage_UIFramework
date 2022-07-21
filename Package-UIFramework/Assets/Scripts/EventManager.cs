using System.Collections.Generic;
using UnityEngine.Events;

public class UnityObjectEvent : UnityEvent<object> { }

public static class EventManager
{
    private static Dictionary<string, UnityObjectEvent> objectEvents = new Dictionary<string, UnityObjectEvent>();
    private static Dictionary<string, UnityEvent> events = new Dictionary<string, UnityEvent>();

    public static void StartListening(string eventName, UnityAction<object> listener)
    {
        UnityObjectEvent thisEvent = null;

        if (objectEvents.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
            return;
        }

        thisEvent = new UnityObjectEvent();
        thisEvent.AddListener(listener);
        objectEvents.Add(eventName, thisEvent);
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;

        if (events.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
            return;
        }

        thisEvent = new UnityEvent();
        thisEvent.AddListener(listener);
        events.Add(eventName, thisEvent);
    }

    public static void StopListening(string eventName, UnityAction<object> listener)
    {
        UnityObjectEvent thisEvent = null;
        if (objectEvents.TryGetValue(eventName, out thisEvent))
            thisEvent.RemoveListener(listener);
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (events.TryGetValue(eventName, out thisEvent))
            thisEvent.RemoveListener(listener);
    }

    public static void Trigger(string eventName, object argument)
    {
        UnityObjectEvent thisEvent = null;
        if (objectEvents.TryGetValue(eventName, out thisEvent))
            thisEvent.Invoke(argument);
    }

    public static void Trigger(string eventName)
    {
        UnityEvent thisEvent = null;
        if (events.TryGetValue(eventName, out thisEvent))
            thisEvent.Invoke();
    }
}

