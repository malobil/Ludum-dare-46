using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour, IUnconstructable
{
    private ConstructableTerrain previousTile;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
