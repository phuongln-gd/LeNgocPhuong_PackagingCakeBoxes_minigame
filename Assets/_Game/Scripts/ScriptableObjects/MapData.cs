using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MapData", menuName = "ScriptableObjects/MapData")]
public class MapData : ScriptableObject
{
    [SerializeField] List<Map> maps;

    public Map getMapByID(int id)
    {
        for (int i = 0; i < maps.Count; i++)
        {
            if (maps[i].ID == id)
            {
                return maps[i];
            }
        }
        return null;
    }
    public int mapAmount => maps.Count;
}

[System.Serializable]
public class Map
{
    [Header("--Map Data--")]
    public int ID;
    public int typeMap;
    public int cakePos, boxPos;
    public int[] obstaclePos;
}
