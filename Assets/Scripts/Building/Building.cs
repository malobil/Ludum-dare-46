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
        Destroy(gameObject);
    }

    public void Setup(ConstructableTerrain constructTile)
    {
        previousTile = constructTile;   
    }

    // Start is called before the first frame update
    void Start()
    {
        if(canBeCollected)
        {
            StartCoroutine(cooldownMoney());
        }
       
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
