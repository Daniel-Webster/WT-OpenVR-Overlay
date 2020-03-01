using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private Texture2D mapTexture;

    public GameObject AirfieldPrefab;
    public GameObject PlayerPrefab;
    public GameObject MapObjectivePrefab;
    private Material mapMaterial;
    private Renderer groundRendererCache; 
    private WTMapObject player;
    Queue<GameObject> AirfieldQueue;
    Queue<GameObject> MapObjectivesQueue;
    Dictionary<string, WTMapObject> ExistingAirfields;
    public Renderer groundRenderer { 
        get {
            if(groundRendererCache == null) {
                groundRendererCache = transform.Find("Ground").gameObject.GetComponent<Renderer>();
            }
            return groundRendererCache;
        }
    }

    // Update is called once per frame
    void Start()
    {
        this.InstantiatePlayer();
        this.InstantiateAirfieldQueue();
        this.InstantiateMapObjectiveQueue();
        this.mapMaterial = Instantiate(groundRenderer.sharedMaterial);
        groundRenderer.sharedMaterial = this.mapMaterial;
        WTEvents.RegisterEventHandler(WTEvent.Type.mapImageChange, UpdateMapTexture);
        WTEvents.RegisterEventHandler(WTEvent.Type.mapObjectsChange, this.HandleMapObjectStateChange);
        WTEvents.RegisterEventHandler(WTEvent.Type.gameLoad, this.InstantiateAirfieldQueue);
    }

    void InstantiatePlayer() {
        WTLogger.LogInfo("Instantiating Player");
        GameObject newPlayer = (GameObject) Instantiate(PlayerPrefab, new Vector3(), PlayerPrefab.transform.rotation);
        newPlayer.transform.parent = gameObject.transform;
        this.player = newPlayer.GetComponent<Player>();
    }
    void InstantiateAirfieldQueue(WTEvent e) {
        InstantiateAirfieldQueue();
    }
    void InstantiateAirfieldQueue() {
        WTLogger.LogInfo("Instantiating Airfield Queue");
        AirfieldQueue = new Queue<GameObject>();
        ExistingAirfields = new Dictionary<string, WTMapObject>();
        for(var i = 0; i < 10; i ++) {
            GameObject airfield = (GameObject) Instantiate(AirfieldPrefab, transform.position, new Quaternion());
            airfield.transform.parent = gameObject.transform;
            AirfieldQueue.Enqueue(airfield);
        }
    }

    void InstantiateMapObjectiveQueue() {
        WTLogger.LogInfo("Instantiating Objective Queue");
        MapObjectivesQueue = new Queue<GameObject>();
        for(var i = 0; i < 10; i ++) {
            GameObject mapObjective = (GameObject) Instantiate(MapObjectivePrefab, transform.position, Quaternion.Euler(90,0,0));
            mapObjective.transform.parent = gameObject.transform;
            MapObjectivesQueue.Enqueue(mapObjective);
        }
    }

    private List<WTMapObject> wtMapObjects = new List<WTMapObject>();

    void HandleMapObjectStateChange(WTEvent e) {
        //Create Objects on the Map
        //Update existing objects location data
        MapObjectsState state = (MapObjectsState) e.detail;
        if(state.mapObjects != null) {
            for(var i = 0; i < state.mapObjects.Length; i ++) {
                WTLogger.LogInfo(state.mapObjects[i].Type);
                switch(state.mapObjects[i].Type){
                    case "airfield":
                        UpdateAirfields(state.mapObjects[i]);
                        break;
                    case "aircraft":
                        UpdateAircraft(state.mapObjects[i]);
                        break;
                    default:
                        UpdateMapObjectives(state.mapObjects[i]);
                        break;
                }
            }
        } else {
            WTLogger.LogInfo("Waiting for State Change");
        }
    }

    void UpdateMapObjectives(MapObject objective) {
        GameObject mapObjective = this.MapObjectivesQueue.Dequeue();
        MapObjective mapObjectiveComponent = mapObjective.GetComponent<MapObjective>();
        mapObjectiveComponent.SetIcon(new Icons(objective));
        mapObjectiveComponent.UpdateLocation(new MapPosition(objective));
        this.MapObjectivesQueue.Enqueue(mapObjective);
    }

    void UpdateAircraft(MapObject aircraft) {
        if(aircraft.Icon == "Player") {
            this.player.UpdatePosition(new MapPosition(aircraft));
            // if(this.player.IsHidden()) {
            //     this.player.Show();
            // }
        }
    }

    void UpdateAirfields(MapObject airfield) {
        string key = airfield.Sx+""+airfield.Sy+""+airfield.Ex+""+airfield.Ey;
        if(AirfieldQueue.Count == 0) {
            InstantiateAirfieldQueue();
        }
        if(!ExistingAirfields.ContainsKey(key) && AirfieldQueue.Count > 0) {
            ExistingAirfields.Add(key, AirfieldQueue.Dequeue().GetComponent<Airfield>());
        }
        ExistingAirfields[key].UpdatePosition(new MapPosition(airfield));
        if(ExistingAirfields[key].IsHidden()) {
            ExistingAirfields[key].Show();
        }
    }

    void UpdateMapTexture(WTEvent e) {
        mapTexture = (Texture2D) e.detail;
        SetMapTextureOnMaterial();
    }

    void SetMapTextureOnMaterial() {
        this.mapMaterial.mainTexture = mapTexture;
    }
}
