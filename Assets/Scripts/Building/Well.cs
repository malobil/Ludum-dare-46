using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : Building
{
    public override void CollectThisType()
    {
        BuildingManager.Singleton.CollectAllWell();
        base.CollectThisType();
    }
}
