
using Newtonsoft.Json;
public partial class MapInfo
{
    [JsonProperty("grid_steps")]
    public long[] GridSteps { get; set; }

    [JsonProperty("grid_zero")]
    public long[] GridZero { get; set; }

    [JsonProperty("map_generation")]
    public long MapGeneration { get; set; }

    [JsonProperty("map_max")]
    public long[] MapMax { get; set; }

    [JsonProperty("map_min")]
    public long[] MapMin { get; set; }
}

public partial class MapInfo : Eventful, Serializable 
{
    public object FromJson(string json) {
        MapInfo state = JsonConvert.DeserializeObject<MapInfo>(json);
        state.defaultEvent = WTEvent.Type.mapInfoChange;
        return state;
    }
}