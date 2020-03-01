using Newtonsoft.Json;

public partial class IndicatorsState
{
    [JsonProperty("valid")]
    public bool Valid { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("speed")]
    public double Speed { get; set; }

    [JsonProperty("pedals")]
    public long Pedals { get; set; }

    [JsonProperty("pedals1")]
    public long Pedals1 { get; set; }

    [JsonProperty("pedals2")]
    public long Pedals2 { get; set; }

    [JsonProperty("pedals3")]
    public long Pedals3 { get; set; }

    [JsonProperty("pedals4")]
    public long Pedals4 { get; set; }

    [JsonProperty("pedals5")]
    public long Pedals5 { get; set; }

    [JsonProperty("pedals6")]
    public long Pedals6 { get; set; }

    [JsonProperty("stick_elevator")]
    public long StickElevator { get; set; }

    [JsonProperty("stick_ailerons")]
    public long StickAilerons { get; set; }

    [JsonProperty("vario")]
    public long Vario { get; set; }

    [JsonProperty("altitude_hour")]
    public double AltitudeHour { get; set; }

    [JsonProperty("altitude_min")]
    public double AltitudeMin { get; set; }

    [JsonProperty("altitude_10k")]
    public double Altitude10K { get; set; }

    [JsonProperty("altitude1_hour")]
    public double Altitude1Hour { get; set; }

    [JsonProperty("aviahorizon_roll")]
    public double AviahorizonRoll { get; set; }

    [JsonProperty("aviahorizon_pitch")]
    public double AviahorizonPitch { get; set; }

    [JsonProperty("bank")]
    public double Bank { get; set; }

    [JsonProperty("bank1")]
    public double Bank1 { get; set; }

    [JsonProperty("turn")]
    public long Turn { get; set; }

    [JsonProperty("compass")]
    public double Compass { get; set; }

    [JsonProperty("compass1")]
    public double Compass1 { get; set; }

    [JsonProperty("compass2")]
    public double Compass2 { get; set; }

    [JsonProperty("compass3")]
    public double Compass3 { get; set; }

    [JsonProperty("clock_hour")]
    public double ClockHour { get; set; }

    [JsonProperty("clock_min")]
    public long ClockMin { get; set; }

    [JsonProperty("clock_sec")]
    public long ClockSec { get; set; }

    [JsonProperty("rpm")]
    public double Rpm { get; set; }

    [JsonProperty("rpm1")]
    public long Rpm1 { get; set; }

    [JsonProperty("oil_pressure")]
    public double OilPressure { get; set; }

    [JsonProperty("oil_pressure1")]
    public double OilPressure1 { get; set; }

    [JsonProperty("oil_pressure2")]
    public double OilPressure2 { get; set; }

    [JsonProperty("water_temperature")]
    public double WaterTemperature { get; set; }

    [JsonProperty("fuel")]
    public long Fuel { get; set; }

    [JsonProperty("oxygen")]
    public long Oxygen { get; set; }

    [JsonProperty("gears")]
    public double Gears { get; set; }

    [JsonProperty("gears_lamp")]
    public long GearsLamp { get; set; }

    [JsonProperty("throttle")]
    public long Throttle { get; set; }

    [JsonProperty("throttle1")]
    public long Throttle1 { get; set; }

    [JsonProperty("throttle2")]
    public long Throttle2 { get; set; }

    [JsonProperty("mach")]
    public double Mach { get; set; }

    [JsonProperty("g_meter")]
    public double GMeter { get; set; }

    [JsonProperty("g_meter_min")]
    public double GMeterMin { get; set; }

    [JsonProperty("g_meter_max")]
    public long GMeterMax { get; set; }

    [JsonProperty("blister1")]
    public long Blister1 { get; set; }

    [JsonProperty("blister2")]
    public long Blister2 { get; set; }

    [JsonProperty("blister3")]
    public long Blister3 { get; set; }
}

public partial class IndicatorsState : Eventful, Serializable
{
    public object FromJson(string json) {
        IndicatorsState state = JsonConvert.DeserializeObject<IndicatorsState>(json);   
        state.defaultEvent = WTEvent.Type.indicatorsStateChange;
        return state; 
    }
}