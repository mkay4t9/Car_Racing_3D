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
    public float BrakingForce = 3000f;
    public float presentAccelerationForce = 0f;
    public float presentBrakingForce = 0f;

    [Header("Car Steering")]
    private float steeringTorque = 35f;
    private float presentSteeringTorque = 0f;

    private void Update()
    {
        MoveCar();
        CarSteering();
        ApplyBrakes();
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

        SteeringWheels(FrontLeftWheelCollider, FrontLeftWheelTransform);
        SteeringWheels(FrontRightWheelCollider, FrontRightWheelTransform);
        SteeringWheels(BackLeftWheelCollider, BackLeftWheelTransform);
        SteeringWheels(BackRightWheelCollider, BackRightWheelTransform);
    }

    private void SteeringWheels(WheelCollider WC, Transform WT)
    {
        Vector3 position;
        Quaternion rotation;

        WC.GetWorldPose(out position, out rotation);

        WT.position = position;
        WT.rotation = rotation;
    }

    private void ApplyBrakes()
    {
        if (Input.GetKey(KeyCode.Space))
            presentBrakingForce = BrakingForce;
        
        else
            presentBrakingForce = 0f;

        FrontLeftWheelCollider.brakeTorque = presentBrakingForce;
        FrontRightWheelCollider.brakeTorque = presentBrakingForce;
        BackLeftWheelCollider.brakeTorque = presentBrakingForce;
        BackRightWheelCollider.brakeTorque = presentBrakingForce;       
    }
}
