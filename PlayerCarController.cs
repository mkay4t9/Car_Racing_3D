using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    [Header("Wheels Collider")]
    public WheelCollider FrontLeftWheelCollider;
    public WheelCollider FrontRightWheelCollider;
    public WheelCollider BackLeftWheelCollider;
    public WheelCollider BackRightWheelCollider;

    [Header("Wheels Transform")]
    public Transform FrontLeftWheelTransform;
    public Transform FrontRightWheelTransform;
    public Transform BackLeftWheelTransform;
    public Transform BackRightWheelTransform;

    public float AccelerationForce = 300f;
    public float BreakingForce = 3000f;
    public float presentAccelerationForce = 0f;
    public float presentBreakingForce = 0f;

    [Header("Car Steering")]
    private float steeringTorque = 35f;
    private float presentSteeringTorque = 0f;

    private void Update()
    {
        MoveCar();
        CarSteering();
    }

    private void MoveCar()
    {
        // All Wheel Drive (Power given to All 4 Wheels)
        FrontLeftWheelCollider.motorTorque = presentAccelerationForce;
        FrontRightWheelCollider.motorTorque = presentAccelerationForce;
        BackLeftWheelCollider.motorTorque = presentAccelerationForce;
        BackRightWheelCollider.motorTorque = presentAccelerationForce;

        presentAccelerationForce = AccelerationForce * Input.GetAxis("Vertical");
    }

    private void CarSteering()
    {
        presentSteeringTorque = steeringTorque * Input.GetAxis("Horizontal");

        FrontLeftWheelCollider.steerAngle = presentSteeringTorque;
        FrontRightWheelCollider.steerAngle = presentSteeringTorque;
    }
}