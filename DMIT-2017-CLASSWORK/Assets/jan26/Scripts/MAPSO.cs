using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MAPSO", menuName = "Scriptable Objects/MAPSO")]
public class MAPSO : ScriptableObject
{
    public GameObject prefab;
    public int mapID;
    public string mapName;
    public List<MapEntryPoint> entryPoints;
}

[Serializable]
public class MapEntryPoint
{
    public int entryPointID;
    public Vector3Int cell;
    public PlayerAnimationState targetState;
}
