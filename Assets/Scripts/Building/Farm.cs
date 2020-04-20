using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Building
{
    public override void CollectThisType()
    {
        BuildingManager.Singleton.CollectAllFarm();
        base.CollectThisType();
    }
}