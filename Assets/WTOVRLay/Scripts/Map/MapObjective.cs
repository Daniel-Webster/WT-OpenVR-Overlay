using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjective : MonoBehaviour
{
    Icons ico;
    public void SetIcon(Icons ico) {
        this.ico = ico;
        this.textMesh.text = ico.GetIconText();
        this.textMesh.color = ico.GetColor();
        this.transform.localScale = ico.GetScale();
    }

    public void UpdateLocation(MapPosition pos) {
        this.transform.localPosition = pos.CalculatePosition();
    }
    TextMesh textMesh;
    
    void Start()
    {
        this.textMesh = GetComponent<TextMesh>();
    }

}
