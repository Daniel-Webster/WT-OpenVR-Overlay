using Newtonsoft.Json;

public partial class MissionState
{
    [JsonProperty("objectives")]
    public Objective[] Objectives { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }
}

public partial class Objective
{
    [JsonProperty("primary")]
    public bool Primary { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }
}

public partial class MissionState : Eventful, Serializable
{
    public object FromJson(string json){
        MissionState state = JsonConvert.DeserializeObject<MissionState>(json);
        state.defaultEvent = WTEvent.Type.missionStateChange;
        return state;
    }
}