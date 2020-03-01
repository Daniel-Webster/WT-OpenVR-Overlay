using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Eventful {
    public WTEvent.Type defaultEvent { get; protected set; }
}

public class WTEvent {

    public object detail;    
    public WTEvent(object detail) {
        this.detail = detail;
    }

    public enum Type {
        aircraftStateChange,
        indicatorsStateChange,
        missionStateChange,
        mapStateChange,
        mapObjectsChange,
        mapInfoChange,
        stateChange,
        mapImageChange,
        gameLoad,
    }
}

public static class WTEvents
{
    public delegate void EventHandler(WTEvent data);    
    private static Dictionary<WTEvent.Type, List<EventHandler>> handlerDict =  new Dictionary<WTEvent.Type, List<EventHandler>>();
    public static void RegisterEventHandler(WTEvent.Type e ,EventHandler handler) {
        if(!handlerDict.ContainsKey(e)) {
            List<EventHandler> handlers = new List<EventHandler>();
            handlers.Add(handler);
            handlerDict.Add(e, handlers);
        } else {
            handlerDict[e].Add(handler);
        }
    }

    public static void PublishEvent(WTEvent.Type t, WTEvent e) {
        WTLogger.LogEvent(t, e);
        if(handlerDict.ContainsKey(t)) {
            foreach(EventHandler handle in handlerDict[t]) {
                handle(e);
            }
        }
    }
}
