using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, WTMapObject
{
    public void UpdatePosition(MapPosition position) {
        position.indicators = this.indicators;
        Vector3 currentPlayerPosition = position.CalculatePosition();
        Vector3 positionOnMap = new Vector3(currentPlayerPosition.x, 0.0f, currentPlayerPosition.z);
        this.transform.localPosition = currentPlayerPosition;
        // this.playerLineRenderer.SetPositions(new Vector3[] {
        //     currentPlayerPosition, 
        //     positionOnMap
        // });
    }

    public void Show() {
    }

    public bool IsHidden() {
        return false;
    }

    void Start() {
        WTEvents.RegisterEventHandler(WTEvent.Type.indicatorsStateChange, this.HandleIndicatorsChange);
    }

    IndicatorsState indicators;
    void HandleIndicatorsChange(WTEvent e) {
        this.indicators = (IndicatorsState) e.detail;
        this.transform.rotation = Quaternion.Euler(-90, 0, (float)indicators.Compass);
    }

}
