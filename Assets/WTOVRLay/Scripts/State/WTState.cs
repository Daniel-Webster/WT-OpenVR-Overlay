using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class WTState<T> : WTService where T : Eventful, Serializable
{
    public WTState(string service, int waitTime) : base(service, waitTime) { }
    public T state;
    
    void UpdateState(string json) {
        //Debug.Log("Updating State: "+service + "\r\n"+json);
        this.state = (T) Activator.CreateInstance(typeof(T));
        this.state = (T) state.FromJson(json);
        WTEvents.PublishEvent(this.state.defaultEvent, new WTEvent(this.state));
    }

    public IEnumerator GetState()
    {   
        return HTTPRequest.GetRecursive(URL+service, UpdateState, waitTime);
    }

}
