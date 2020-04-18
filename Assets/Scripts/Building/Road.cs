using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : Building
{
    public List<Road> connectedRoad;

    public void ConnectRoad(Road road)
    {
        connectedRoad.Add(road);
    }

    public override void DestroyMe()
    {
        foreach(Road nearedRoad in connectedRoad)
        {
            nearedRoad.RemoveRoad(this);
        }

        base.DestroyMe();
    }

    public void RemoveRoad(Road road)
    {
     
        if (connectedRoad.Contains(road))
        {
            connectedRoad.Remove(road);
            Debug.Log("dss");

        }
    }
}
