using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour, IUnconstructable
{
    private ConstructableTerrain previousTile;
    public bool canBeCollected = true;
    public BuildingDatas data;
    public GameObject collectButton;

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
}
