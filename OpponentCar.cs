using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCar : MonoBehaviour
{
    [Header("Car Engine")]
    public float movingSpeed = 5f;
    public float turningSpeed = 50f;
    public float brakeSpeed = 12f;

    [Header("Destination Variables")]
    public Vector3 destination;
    public bool destinationReached;

    public Timer timer;

    private void Awake()
    {
        timer = GameObject.Find("EventSystem").GetComponent<Timer>();
    }

    private void Update()
    {
        if(timer.isGameStart)
            Drive();
    }
    public void Drive()
    {
        if (transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;

            if (destinationDistance >= brakeSpeed)
            {
                //Steering
                destinationReached = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);

                //Move Vehicle
                transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
            }
            else
            {
                destinationReached = true;
            }
        }
    }

    public void LocateDestination(Vector3 destination)
    {
        this.destination = destination;
        destinationReached = false;
    }
}
