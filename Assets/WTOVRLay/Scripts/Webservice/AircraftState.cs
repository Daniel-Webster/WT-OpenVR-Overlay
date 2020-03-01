using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public partial class AircraftState
{
    [JsonProperty("valid")]
    public bool Valid { get; set; }

    [JsonProperty("aileron, %")]
    public long Aileron { get; set; }

    [JsonProperty("elevator, %")]
    public long Elevator { get; set; }

    [JsonProperty("rudder, %")]
    public long Rudder { get; set; }

    [JsonProperty("flaps, %")]
    public long Flaps { get; set; }

    [JsonProperty("gear, %")]
    public long Gear { get; set; }

    [JsonProperty("airbrake, %")]
    public long Airbrake { get; set; }

    [JsonProperty("H, m")]
    public long HM { get; set; }

    [JsonProperty("TAS, km/h")]
    public long TasKmH { get; set; }

    [JsonProperty("IAS, km/h")]
    public long IasKmH { get; set; }

    [JsonProperty("M")]
    public long M { get; set; }

    [JsonProperty("AoA, deg")]
    public double AoADeg { get; set; }

    [JsonProperty("AoS, deg")]
    public double AoSDeg { get; set; }

    [JsonProperty("Ny")]
    public long Ny { get; set; }

    [JsonProperty("Vy, m/s")]
    public long VyMS { get; set; }

    [JsonProperty("Wx, deg/s")]
    public long WxDegS { get; set; }

    [JsonProperty("Mfuel, kg")]
    public long MfuelKg { get; set; }

    [JsonProperty("Mfuel0, kg")]
    public long Mfuel0Kg { get; set; }

    [JsonProperty("throttle 1, %")]
    public long Throttle1 { get; set; }

    [JsonProperty("power 1, hp")]
    public long Power1Hp { get; set; }

    [JsonProperty("RPM 1")]
    public long Rpm1 { get; set; }

    [JsonProperty("manifold pressure 1, atm")]
    public long ManifoldPressure1Atm { get; set; }

    [JsonProperty("oil temp 1, C")]
    public long OilTemp1C { get; set; }

    [JsonProperty("thrust 1, kgs")]
    public long Thrust1Kgs { get; set; }

    [JsonProperty("efficiency 1, %")]
    public long Efficiency1 { get; set; }
}

public partial class AircraftState : Eventful, Serializable
{
    public object FromJson(string json){
        AircraftState state = JsonConvert.DeserializeObject<AircraftState>(json);
        state.defaultEvent = WTEvent.Type.aircraftStateChange;
        return state;
    }
}    

