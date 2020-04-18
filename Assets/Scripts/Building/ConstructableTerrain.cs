using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConstructableTerrain : MonoBehaviour, IConstructable
{
    private bool IsPreviewed = false;

    public virtual void Construct(BuildingDatas buildingToBuild, int rotation)
    {
        GameObject spawnedBuilding = Instantiate(buildingToBuild.prefabs[rotation], transform.position, buildingToBuild.prefabs[rotation].transform.rotation);
        spawnedBuilding.GetComponent<Building>().Setup(this);
        HideThis();
    }

    public void HideThis()
    {
        gameObject.SetActive(false);
    }

    public void PreviewConstruct(BuildingDatas buildingToBuild, int rotation)
    {
       
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
