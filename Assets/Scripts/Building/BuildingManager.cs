﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Singleton { get; private set; }

    public Building autel;

    public List<Building> allBuildings;

    private List<Building> checkedBuilding = new List<Building>();
    private List<Building> buildingToCheck = new List<Building>();

    private void Awake()
    {
        if(Singleton)
        {
            Destroy(this);
        }
        else
        {
            Singleton = this;
        }
    }

    public void AddBuildingToList(Building buildingToAdd)
    {
        allBuildings.Add(buildingToAdd);
    }

    public void RemoveBuildingToList(Building buildingToAdd)
    {
        allBuildings.Remove(buildingToAdd);
    }

    public void CheckConnectedPath()
    {
        buildingToCheck.Clear();

        for(int i = 0; i < allBuildings.Count; i++)
        {
            buildingToCheck.Add(allBuildings[i]);
        }

        checkedBuilding.Clear();
        autel.ConnectToAutel();

        foreach(Building remainingBuilding in buildingToCheck)
        {
            remainingBuilding.UnConnectToAutel();
        }
    }

    public void CheckedBuilding(Building checkedB)
    {
        buildingToCheck.Remove(checkedB);
        checkedBuilding.Add(checkedB);
    }

    public bool CheckIfBuildingIsCheck(Building toCheck)
    {
        return checkedBuilding.Contains(toCheck);
    }

    public Transform GetABuildingPosition()
    {
        int tempRdm = Random.Range(0, checkedBuilding.Count - 1);
        return checkedBuilding[tempRdm].transform;
    }
}
