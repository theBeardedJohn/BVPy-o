using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class VehicleMovement : MonoBehaviour
{
    

    [SerializeField] WheelCollider wheelColliderLeftFront;
    [SerializeField] WheelCollider wheelColliderRightFront;
    [SerializeField] WheelCollider wheelColliderLeftBack;
    [SerializeField] WheelCollider wheelColliderRightBack;
    
    [SerializeField] Transform wheelLeftFront;
    [SerializeField] Transform wheelRightFront;
    [SerializeField] Transform wheelLeftBack;
    [SerializeField] Transform wheelRightBack;


    public void VehicleMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Drive();



        }


        else if (context.canceled)
        {
            verticalInput = context.ReadValue<float>();

        }



    }



    void FixedUpdate () 
    {
        


    }


}
