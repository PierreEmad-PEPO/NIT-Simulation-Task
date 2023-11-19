using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    private static Dictionary<EventEnum, UnityEvent> events = new Dictionary<EventEnum, UnityEvent>();

    public static void AddEvent(EventEnum eventEnum)
    {
        if (events.ContainsKey(eventEnum) == false)
        {
            UnityEvent unityEvent = new UnityEvent();
            events.Add(eventEnum, unityEvent);
        }
    }

    public static void AddListener(EventEnum eventEnum, UnityAction action)
    {
        if (events.ContainsKey(eventEnum))
        {
            events[eventEnum].AddListener(action);
        }
    }

    public static void Invoke(EventEnum eventEnum)
    {
        if (events.ContainsKey(eventEnum))
        {
            events[eventEnum].Invoke();
        }
    }
}
