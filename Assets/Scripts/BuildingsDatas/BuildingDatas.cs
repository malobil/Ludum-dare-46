using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Create new building", order = 1)]
public class BuildingDatas : ScriptableObject
{
    public string buildingName;
    [Header("Build")]
    public float cost;
    [Header("Gain")]
    public float productionTime;
    public float faith;
    public float population;
    public float money;
    public float entertainment;
    public float food;
    public float water;

    public List<GameObject> prefabs;
}
