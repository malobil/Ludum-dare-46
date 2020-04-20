using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building
{
    public override void ConnectToAutel()
    {
        if (!isConectedToTheAutel)
        {
            PlayerManager.Singleton.AddPopulationCapacity(data.population);
        }

        base.ConnectToAutel();
    }
}
