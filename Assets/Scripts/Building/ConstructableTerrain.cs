using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConstructableTerrain : MonoBehaviour, IConstructable
{
    public ConstructableTerrain connectedTilesUp;
    public ConstructableTerrain connectedTilesDown;
    public ConstructableTerrain connectedTilesLeft;
    public ConstructableTerrain connectedTilesRight;

    private List<ConstructableTerrain> constructs = new List<ConstructableTerrain>();

    private void Start()
    {
        constructs.Add(this);    
    }

    public virtual void Construct(BuildingDatas buildingToBuild, int rotation)
    {
      
        GameObject spawnedBuilding = Instantiate(buildingToBuild.prefabs[rotation], new Vector3(0f,9999f,0f), buildingToBuild.prefabs[rotation].transform.rotation);
        if (buildingToBuild.tileSize > 1)
        {
            HideNearTile(spawnedBuilding.GetComponent<Building>().buildingDirection);
        }
        HideThis();
        spawnedBuilding.GetComponent<Building>().Setup(constructs, buildingToBuild);
        spawnedBuilding.transform.position = transform.position;
        
        

        
    }

    public void HideThis()
    {
        gameObject.SetActive(false);
    }

    public void ShowThis()
    {
        gameObject.SetActive(true);
    }

    public void AddConnectedTile(ConstructableTerrain connected,Direction tileDir)
    {
        switch(tileDir)
        {
            case Direction.Up:
                connectedTilesUp = connected;
                break;
            case Direction.Down:
                connectedTilesDown = connected;
                break;
            case Direction.Left:
                connectedTilesLeft = connected;
                break;
            case Direction.Right:
                connectedTilesRight = connected;
                break;
        }
    }

    public void RemoveConnectedTile(Direction tileDir)
    {
        switch (tileDir)
        {
            case Direction.Up:
                connectedTilesUp = null;
                break;
            case Direction.Down:
                connectedTilesDown = null;
                break;
            case Direction.Left:
                connectedTilesLeft = null;
                break;
            case Direction.Right:
                connectedTilesRight = null;
                break;
        }
    }

    void HideNearTile(Direction dir)
    {
        switch (dir)
        {
            case Direction.Up:
                connectedTilesUp.HideThis();
                constructs.Add(connectedTilesUp);
                break;

            case Direction.Down:
                connectedTilesDown.HideThis();
                constructs.Add(connectedTilesDown);
                break;

            case Direction.Left:
                connectedTilesLeft.HideThis();
                constructs.Add(connectedTilesLeft);
                break;

            case Direction.Right:
                connectedTilesRight.HideThis();
                constructs.Add(connectedTilesRight);
                break;
        }

    }

    public bool CheckNearTile(Direction dir, int tiles)
    {
        if(tiles <= 1)
        {
            return true;
        }
            switch (dir)
            {
                case Direction.Up:
                    if(connectedTilesUp == null)
                    {
                        return false;
                    }
                    break;

                case Direction.Down:
                    if (connectedTilesDown == null)
                    {
                        return false;
                    }
                    break;

                case Direction.Left:
                    if (connectedTilesLeft == null)
                    {
                        return false;
                    }
                    break;

                case Direction.Right:
                    if (connectedTilesRight == null)
                    {
                        return false;
                    }
                    break;
            }

        return true;
    }
}
