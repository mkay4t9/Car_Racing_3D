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

    private void Update()
    {
        MoveCar();
    }

    private void MoveCar()
    {
        FrontLeftWheelCollider.motorTorque = presentAccelerationForce;
        FrontRightWheelCollider.motorTorque = presentAccelerationForce;


        presentAccelerationForce = AccelerationForce * Input.GetAxis("Vertical");
    }
}
