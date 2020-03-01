using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airfield : MonoBehaviour, WTMapObject
{
    public MapObject mapObject;
    public void UpdatePosition(MapPosition mapPosition) { 
        if(this.lineRenderer == null) {
            this.lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        }
        this.lineRenderer.SetPositions(mapPosition.CalculateAirfieldPositions());
    }
    LineRenderer lineRenderer;
    
    void Start()
    {
        this.lineRenderer = this.gameObject.GetComponent<LineRenderer>();
    }

    public void Show(){
        this.lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        this.lineRenderer.enabled = true;
    }

    public bool IsHidden() {
        return !this.lineRenderer.enabled;
    }
}
