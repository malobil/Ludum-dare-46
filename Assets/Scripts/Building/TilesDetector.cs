using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { Up, Down, Left, Right}

public class TilesDetector : MonoBehaviour
{
    public Direction dir;

    private ConstructableTerrain associateTile;

    private ConstructableTerrain connectedTile;

    private void Start()
    {
        associateTile = GetComponentInParent<ConstructableTerrain>();
    }

    private void OnTriggerEnter(Collider other)
    {
        connectedTile = other.gameObject.GetComponentInParent<ConstructableTerrain>();
        associateTile.AddConnectedTile(connectedTile,dir);
    }

    private void OnTriggerExit(Collider other)
    {
        associateTile.RemoveConnectedTile(dir);
    }
}
