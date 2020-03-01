using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WTStateManager : MonoBehaviour
{
    private WTState<MapInfo> mapInfoState = new WTState<MapInfo>("map_info.json", 30);
    private WTState<AircraftState> aircraftState = new WTState<AircraftState>("state", 0);
    private WTState<IndicatorsState> indicatorsState = new WTState<IndicatorsState>("indicators", 0);
    private WTState<MissionState> missionState = new WTState<MissionState>("mission.json", 3);
    private WTState<MapObjectsState> mapState = new WTState<MapObjectsState>("map_obj.json", 0);
    private WTTexture mapImage = new WTTexture("map.img", WTEvent.Type.mapImageChange);
    
    void Start()
    {
        StartCoroutine(mapInfoState.GetState());
        StartCoroutine(aircraftState.GetState());
        StartCoroutine(indicatorsState.GetState());
        StartCoroutine(missionState.GetState());
        StartCoroutine(mapState.GetState());
        StartCoroutine(mapImage.GetTexture());
    }

}
