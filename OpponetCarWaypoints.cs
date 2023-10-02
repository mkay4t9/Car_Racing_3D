using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpponetCarWaypoints : MonoBehaviour
{
    [Header("Opponent Car")]
    public OpponentCar opponentCar;
    public Waypoint currentWaypoint;

    private void Awake()
    {
        opponentCar = GetComponent<OpponentCar>();
    }

    private void Start()
    {
        opponentCar.LocateDestination(currentWaypoint.GetPosition());
    }

    private void Update()
    {
        if (opponentCar.destinationReached)
        {
            currentWaypoint = currentWaypoint.nextWaypoint;
            opponentCar.LocateDestination(currentWaypoint.GetPosition());
        }
    }
}
