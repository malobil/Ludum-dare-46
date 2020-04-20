using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class People : MonoBehaviour
{
    private AIDestinationSetter destinationComp;

    private Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        destinationComp = GetComponent<AIDestinationSetter>();
        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if(destination == null)
        {
            SetDestination();
        }

        if (Vector3.Distance(transform.position, destination.position) <= 5f)
        {
            SetDestination();
        }
    }

    void SetDestination()
    {
        destination = BuildingManager.Singleton.GetABuildingPosition();
        destinationComp.target = destination;
        StopCoroutine(ChangeDestination());
        StartCoroutine(ChangeDestination());
    }

    IEnumerator ChangeDestination()
    {
        yield return new WaitForSeconds(20f);
        SetDestination();
    }
}
