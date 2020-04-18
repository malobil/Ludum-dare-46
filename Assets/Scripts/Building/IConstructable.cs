using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConstructable
{
    void Construct(BuildingDatas buildingToBuild, int rotation);
    void PreviewConstruct(BuildingDatas buildingToBuild, int rotation);
}
