using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class BvpMovement : MonoBehaviour
{
    public Transform centerOfMass;

    public WheelCollider wheelColliderLeftFront;
    public WheelCollider wheelColliderRightFront;
    public WheelCollider wheelColliderLeftBack;
    public WheelCollider wheelColliderRightBack;

    public Transform wheelLeftFront;
    public Transform wheelRightFront;
    public Transform wheelLeftBack;
    public Transform wheelRightBack;

    public float motorTorque = 130f;
    public float maxSteer = 20f;
    public float breakForce;

    private Rigidbody _rigidbody;

    public GameObject manager;
    public bool motorBool;

    public GameObject bvp;


    public ParticleSystem exhaustParticleL;
    public ParticleSystem exhaustParticleR;

    private float basicEmmision;
    private float basicLifetime;
    private float basicSpeed;


    // INPUT SYSTEM
    public float verticalInput;
    public float horizontalInput;

    


    void Start()
    {

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
        basicEmmision = 10f;
        basicSpeed = 2.4f;
        basicLifetime = 0.74f;

      



    }

    //private void OnMovement(InputValue moveValue)
    //{   
    //    Debug.Log(moveValue.Get<float>());

    //}

    public void InputAssign(InputAction.CallbackContext context)
    {
        
        if (context.performed)
        {
            verticalInput = context.ReadValue<float>();
            Debug.Log(verticalInput);


        }
    

        else if (context.canceled)
        {
            verticalInput = context.ReadValue<float>();
            Debug.Log(verticalInput);
        }
    
        
       
    }


    void Break()
    {
        wheelColliderLeftBack.brakeTorque = breakForce;
        wheelColliderRightBack.brakeTorque = breakForce;



    }



    void FixedUpdate()
    {
        motorBool = manager.GetComponent<BvpEngine>().motorIsRuning;
        

        if (motorBool == true)
        {
        wheelColliderLeftBack.motorTorque = verticalInput * motorTorque;
        wheelColliderRightBack.motorTorque = verticalInput * motorTorque;
        
        }
       
       
        
        
        
        
        
        
        wheelColliderLeftFront.steerAngle = Input.GetAxis("Horizontal") * maxSteer;
        wheelColliderRightFront.steerAngle = Input.GetAxis("Horizontal") * maxSteer;




    }



    void Update()
    {
        motorBool = manager.GetComponent<BvpEngine>().motorIsRuning;
        

        if (motorBool == true )
        {
            

            exhaustParticleL.emissionRate = basicEmmision + (Mathf.Abs(Input.GetAxis("Vertical")) * 3f);
            exhaustParticleR.emissionRate = exhaustParticleL.emissionRate;

            exhaustParticleL.startLifetime = basicLifetime + (Mathf.Abs(Input.GetAxis("Vertical")) * 1f);
            exhaustParticleR.startLifetime = exhaustParticleL.startLifetime;

            exhaustParticleL.startSpeed = basicSpeed + (Mathf.Abs(Input.GetAxis("Vertical")) * 1.2f);
            exhaustParticleR.startSpeed = exhaustParticleL.startSpeed;

            

            var pos = Vector3.zero;
            var rot = Quaternion.identity;

            wheelColliderLeftFront.GetWorldPose(out pos, out rot);
            wheelLeftFront.position = pos;
            wheelLeftFront.rotation = rot;

            wheelColliderRightFront.GetWorldPose(out pos, out rot);
            wheelRightFront.position = pos;
            wheelRightFront.rotation = rot * Quaternion.Euler(0, 180, 0);

            wheelColliderLeftBack.GetWorldPose(out pos, out rot);
            wheelLeftBack.position = pos;
            wheelLeftBack.rotation = rot;

            wheelColliderRightBack.GetWorldPose(out pos, out rot);
            wheelRightBack.position = pos;
            wheelRightBack.rotation = rot * Quaternion.Euler(0, 180, 0);
        }
        if (motorBool == false)
        {
            Break();

        }

    }





}