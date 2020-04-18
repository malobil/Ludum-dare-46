using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour, IUnconstructable
{
    private ConstructableTerrain previousTile;
    public bool canBeCollected = true;
    public BuildingDatas data;
    public GameObject collectButton;

    public List<Building> connectedRoad;
    public bool isConectedToTheAutel = false ;

    public virtual void UnContruct()
    {
        previousTile.ShowThis();
        PlayerManager.Singleton.AddMoney(data.cost / 2f);
        DestroyMe();
    }

    public void Setup(ConstructableTerrain constructTile, BuildingDatas newDatas)
    {
        previousTile = constructTile;
        data = newDatas;
    }

    public virtual void OnEnter()
    {
        if (canBeCollected)
        {
            StartCoroutine(cooldownMoney());
        }
    }

    public virtual void DestroyMe()
    {
        foreach (Road nearedRoad in connectedRoad)
        {
            nearedRoad.RemoveRoad(this);
        }

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

    IEnumerator cooldownMoney()
    {
        yield return new WaitForSeconds(10f);
        Gain();
    }

    public void Gain()
    {
        collectButton.SetActive(true);
    }

    public virtual void Collect()
    {
        collectButton.SetActive(false);
        StartCoroutine(cooldownMoney());
        PlayerManager.Singleton.AddMoney(data.money);
        PlayerManager.Singleton.AddFaith(data.faith);
        PlayerManager.Singleton.AddEntertainment(data.entertainment);
        PlayerManager.Singleton.AddFood(data.food);
        PlayerManager.Singleton.AddPopulation(data.population);
        PlayerManager.Singleton.AddWater(data.water);
    }

    //WIP
    public void CheckIfConnected()
    {
        foreach(Building roads in connectedRoad)
        {
            if(roads.isConectedToTheAutel)
            {
                isConectedToTheAutel = true;
            }
        }
    }

    void CheckAllConnection()
    {

    }
    //WIP

    public void ConnectRoad(Building road)
    {
        connectedRoad.Add(road);
    }

    public void RemoveRoad(Building road)
    {
        if (connectedRoad.Contains(road))
        {
            connectedRoad.Remove(road);
        }
    }

    public bool GetIsConnected()
    {
        return isConectedToTheAutel;
    }
}
