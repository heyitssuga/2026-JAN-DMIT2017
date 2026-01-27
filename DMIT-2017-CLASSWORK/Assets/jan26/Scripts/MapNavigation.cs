using System;
using System.Collections.Generic;
using UnityEngine;

public class MapNavigation : MonoBehaviour
{
   [SerializeField] MapLibrary mapLibrary;
   [SerializeField] private Transform player;
   [SerializeField] private Transform mapParent;
   
   private Dictionary<int, MapData> mapDictionary = new Dictionary<int, MapData>();
   public static MapNavigation instance;

   public GameObject currentMap;

   private void Awake()
   {
      instance = this;
   }

   public void Start()
   {
      InitializeMapLibrary();
   }

   public void InitializeMapLibrary()
   {
      foreach (MAPSO map in mapLibrary.maps)
      {
         mapDictionary.Add(map.mapID, new MapData(map));
      }
   }

   public void GoToMap(int mapID, int entryPointID)
   {
      Destroy(currentMap);
      currentMap = Instantiate(mapDictionary[mapID].prefab, mapParent);
      
      Grid g =  currentMap.GetComponent<Grid>();
      
      Vector3 newPosition = g.GetCellCenterWorld(mapDictionary[mapID].entryPoints[entryPointID].cell);
   }
}

public class MapData
{
   public GameObject prefab;
   public int mapID;
   public string mapName;
   public Dictionary<int, MapEntryPoint> entryPoints;

   public MapData(MAPSO config)
   {
      this.prefab = config.prefab;
      this.mapID = config.mapID;
      this.mapName = config.mapName;

      foreach (MapEntryPoint entryPoint in config.entryPoints)
      {
         entryPoints.Add(entryPoint.entryPointID, entryPoint);
      }
   }
}
