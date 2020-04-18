using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDetector : MonoBehaviour
{
    private Road associateRoad;

    private Road connectedRoad;

    private void Start()
    {
        associateRoad = GetComponentInParent<Road>();
    }

    private void OnTriggerEnter(Collider other)
    {
        connectedRoad = other.gameObject.GetComponentInParent<Road>();
        associateRoad.ConnectRoad(connectedRoad);
    }

    private void OnTriggerExit(Collider other)
    {
        associateRoad.RemoveRoad(connectedRoad);
    }
}
