using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPosition
{
    MapObject mapObject;
    public IndicatorsState indicators {
        private get; set;
    }
    public Vector3 mapPosition;
    public Vector3 airfield_start;
    public Vector3 airfield_end;
    
    public MapPosition() {
    
    }
    public MapPosition(MapObject obj) {
        UpdatePosition(obj);
    }
    
    public MapPosition(MapObject obj, IndicatorsState indicators) {
        UpdatePosition(obj, indicators);
    }
    private void UpdatePosition(MapObject obj, IndicatorsState indicators) {
        this.indicators = indicators;
        this.UpdatePosition(obj);
    }
    private void UpdatePosition(MapObject obj) {
        this.mapObject = obj;
    }
    
    public Vector3 CalculatePosition() {
        this.mapPosition.x = (float)(mapScale - this.mapObject.X * 2 * mapScale);
        this.mapPosition.z = (float)(-mapScale + this.mapObject.Y * 2 * mapScale);
        if(indicators != null) {
            this.mapPosition.y = (float)(indicators.Altitude10K * 0.0005);
        }
        return this.mapPosition;
    }
    const int mapScale = 5;

    public Vector3[] CalculateAirfieldPositions() {
        this.airfield_start.x = (float)(mapScale - this.mapObject.Sx * 2 * mapScale);
        this.airfield_start.z = (float)(-1 * mapScale + this.mapObject.Sy * 2 * mapScale);
        this.airfield_end.x = (float)(mapScale - this.mapObject.Ex * 2 * mapScale);
        this.airfield_end.z = (float)(-mapScale + this.mapObject.Ey * 2 * mapScale);
        return new Vector3[] { this.airfield_end, this.airfield_start };
    }

}
