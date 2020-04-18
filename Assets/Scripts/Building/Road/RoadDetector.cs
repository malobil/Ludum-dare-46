using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDetector : MonoBehaviour
{
    private Building associateRoad;

    private Building connectedRoad;

    private void Start()
    {
        associateRoad = GetComponentInParent<Building>();
    }

    private void OnTriggerEnter(Collider other)
    {
        connectedRoad = other.gameObject.GetComponentInParent<Building>();
        associateRoad.ConnectRoad(connectedRoad);
    }

    private void OnTriggerExit(Collider other)
    {
        associateRoad.RemoveRoad(connectedRoad);
    }
}
