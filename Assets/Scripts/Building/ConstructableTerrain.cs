using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConstructableTerrain : MonoBehaviour, IConstructable
{
    public virtual void Construct(BuildingDatas buildingToBuild, int rotation)
    {
        GameObject spawnedBuilding = Instantiate(buildingToBuild.prefabs[rotation], new Vector3(0f,9999f,0f), buildingToBuild.prefabs[rotation].transform.rotation);
        spawnedBuilding.GetComponent<Building>().Setup(this,buildingToBuild);
        spawnedBuilding.transform.position = transform.position;
        HideThis();
    }

    public void HideThis()
    {
        gameObject.SetActive(false);
    }

    public void ShowThis()
    {
        gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
