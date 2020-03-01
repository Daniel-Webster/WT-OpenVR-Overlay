using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Serializable
{
    object FromJson(string json);
}
