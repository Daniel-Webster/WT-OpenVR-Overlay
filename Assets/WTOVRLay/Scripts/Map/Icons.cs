using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icons
{
    MapObject mapObject;
    string iconText;

    Vector3 scale;

    public Icons(MapObject mapObject) {
        this.mapObject = mapObject;
        SetupIcon();
    }

    public void SetupIcon() {
        
        this.scale = new Vector3(0.1f,0.1f,0.1f);
        switch(mapObject.Icon) {
            case "Airdefence" :
                this.iconText = "4";
                this.scale = new Vector3(0.03f,0.03f,0.03f);
                break;
            case "Structure" :
                this.iconText = "5";
                break;
            case "waypoint" :
                this.iconText = "6";
                break;
            case "capture_zone" :
                this.iconText = "7";
                break;
            case "bombing_point" :
                this.iconText = "8";
                break;
            case "defending_point" :
                this.iconText = "9";
                break;
            case "respawn_base_tank" :
                this.iconText = "0";
                break;
            case "respawn_base_fighter" :
                this.iconText = ".";
                break;
            case "respawn_base_bomber" :
                this.iconText = ":";
                break;
            case "Tracked" :
                this.iconText = "g";
                this.scale = new Vector3(0.01f,0.01f,0.01f);
                break;
            default :
                this.iconText = "0";
                this.scale = new Vector3(0.01f,0.01f,0.01f);
                break;
        }
    }

    public Color GetColor() {
        return new Color(mapObject.RGBColor[0], mapObject.RGBColor[1], mapObject.RGBColor[2]);
    }

    public string GetIconText() {
        return this.iconText;
    }

    public Vector3 GetScale() {
        return this.scale;
    }
}
