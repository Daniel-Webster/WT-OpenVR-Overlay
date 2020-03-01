using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public enum MapObjectType {
    aircraft,
    airfield,

}

public partial class MapObjectsState : Eventful, Serializable
{
    public MapObject[] mapObjects;
    public object FromJson(string json) {
        
        this.defaultEvent = WTEvent.Type.mapObjectsChange;
        this.mapObjects = JsonConvert.DeserializeObject<MapObject[]>(json);
        return this;
    }
}

public partial class MapObject
{
    public Double GetXPosition() {
        if(this.Type == MapObjectType.aircraft.ToString()) {
            return this.X;
        }
        return this.Sx;
    }
    
    public Double GetYPosition() {
        if(this.Type == MapObjectType.aircraft.ToString()) {
            return this.Y;
        }
        return this.Sy; 
    }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("color")]
    public string Color { get; set; }

    [JsonProperty("color[]")]
    public long[] RGBColor { get; set; }

    [JsonProperty("blink")]
    public long Blink { get; set; }

    [JsonProperty("icon")]
    public string Icon { get; set; }

    [JsonProperty("icon_bg")]
    public string IconBg { get; set; }

    [JsonProperty("sx")]
    public double Sx { get; set; }

    [JsonProperty("sy")]
    public double Sy { get; set; }
    
    [JsonProperty("x")]
    public double X { get; set; }

    [JsonProperty("y")]
    public double Y { get; set; }

    [JsonProperty("ex")]
    public double Ex { get; set; }

    [JsonProperty("ey")]
    public double Ey { get; set; }
}
