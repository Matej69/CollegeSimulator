using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class EventManager {

    static private EventManager instance;
    static public EventManager Instance()
    {
        if (instance == null)
        {
            instance = new EventManager();
            instance.InitEventsDictionary();
        }
        return instance;
    }



    private Dictionary<EventEnumType.E_EVENT_ID, UnityEvent> eventsDictionary;
    private void InitEventsDictionary()
    {
        eventsDictionary = new Dictionary<EventEnumType.E_EVENT_ID, UnityEvent>();
    }



    static public void Subscribe(EventEnumType.E_EVENT_ID _eventID, UnityAction _funToCall)
    {
        UnityEvent thisEvent = null;
        if(Instance().eventsDictionary.TryGetValue(_eventID, out thisEvent))
        {
            thisEvent.AddListener(_funToCall);
        }   
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(_funToCall);
            Instance().eventsDictionary.Add(_eventID, thisEvent);
        }                     
    }

    static public void Unsubscribe(EventEnumType.E_EVENT_ID _eventID, UnityAction _funToCall)
    {
        UnityEvent thisEvent = null;
        if (Instance().eventsDictionary.TryGetValue(_eventID, out thisEvent))
        {
            thisEvent.RemoveListener(_funToCall);
        }
        else
        {
            Debug.LogError("TRYING TO REMOVE OBJ FROM EVENT = " + _eventID);
        }
    }

    static public void TriggerEvent(EventEnumType.E_EVENT_ID _eventID)
    {
        UnityEvent thisEvent = null;
        if (Instance().eventsDictionary.TryGetValue(_eventID, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }





}
