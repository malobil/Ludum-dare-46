using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour, IUnconstructable
{
    private ConstructableTerrain previousTile;
    public bool canBeDestroy = true;
    public bool canBeCollected = true;
    public BuildingDatas data;
    public GameObject collectButton;

    private List<Building> connectedRoad = new List<Building>() ;
    private bool isConectedToTheAutel = false ;

    private bool isProducting = false;

    public virtual void UnContruct()
    {
        if(canBeDestroy)
        {
            previousTile.ShowThis();
            PlayerManager.Singleton.AddMoney(data.cost / 2f);
            BuildingManager.Singleton.RemoveBuildingToList(this);

            for(int i = 0; i < connectedRoad.Count; i++)
            {
                connectedRoad[i].RemoveRoad(this);
            }
           
            DestroyMe();
        }
    }

    public void Setup(ConstructableTerrain constructTile, BuildingDatas newDatas)
    {
        BuildingManager.Singleton.AddBuildingToList(this);
        previousTile = constructTile;
        data = newDatas;
    }

    public virtual void OnEnter()
    {

    }

    public virtual void DestroyMe()
    {
        Destroy(gameObject);
    }

    public virtual void OnUpdate()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        OnEnter();
    }

    IEnumerator Production()
    {
        yield return new WaitForSeconds(data.productionTime);
        Gain();
    }

    public void Gain()
    {
        collectButton.SetActive(true);
    }

    public virtual void Collect()
    {
        collectButton.SetActive(false);
       
        PlayerManager.Singleton.AddMoney(data.money);
        PlayerManager.Singleton.AddFaith(data.faith);
        PlayerManager.Singleton.AddEntertainment(data.entertainment);
        PlayerManager.Singleton.AddFood(data.food);
        PlayerManager.Singleton.AddPopulation(data.population);
        PlayerManager.Singleton.AddWater(data.water);
        StartProduction();
    }

    public void ConnectToAutel()
    {
        isConectedToTheAutel = true;
        BuildingManager.Singleton.CheckedBuilding(this);
        StartProduction();

        foreach(Building builds in connectedRoad)
        {
            if(!BuildingManager.Singleton.CheckIfBuildingIsCheck(builds))
            {
                builds.ConnectToAutel();
            }
        }
    }

    void StartProduction()
    {
        if(isConectedToTheAutel && !isProducting && canBeCollected)
        {
            isProducting = true;
            StartCoroutine(Production());
        }
    }

    void StopProduction()
    {
        if(isProducting)
        {
            StopCoroutine(Production());
            isProducting = false;
        }
    }

    public void UnConnectToAutel()
    {
        isConectedToTheAutel = false;
        StopProduction();
    }

    public void ConnectRoad(Building road)
    {
        connectedRoad.Add(road);
        BuildingManager.Singleton.CheckConnectedPath();
    }

    public void RemoveRoad(Building road)
    {
        if (connectedRoad.Contains(road))
        {
            connectedRoad.Remove(road);
            BuildingManager.Singleton.CheckConnectedPath();
        }
    }

    public bool GetIsConnected()
    {
        return isConectedToTheAutel;
    }
}
