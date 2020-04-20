using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tavern : Building
{
    public override void CollectThisType()
    {
        BuildingManager.Singleton.CollectAllTavern();
        base.CollectThisType();
    }
}
