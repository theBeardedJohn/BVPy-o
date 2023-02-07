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

    public float motorTorque = 300f;
    public float maxSteer = 20f;
    public float breakForce;

    private Rigidbody _rigidbody;

    public GameObject manager;
    public bool motorBool;
    public bool handBrake;

    public GameObject bvp;


    public ParticleSystem exhaustParticleL;
    public ParticleSystem exhaustParticleR;

    private float basicEmmision;
    private float basicLifetime;
    private float basicSpeed;


    // INPUT SYSTEM
    public float verticalInput;
    public float horizontalInput;

    public AudioSource runingAudio;


    // TEMP
    [SerializeField] float brzda1;
    [SerializeField] float brzda2;
    [SerializeField] float brzda3;
    [SerializeField] float brzda4;

    [SerializeField] float plyn1;
    [SerializeField] float plyn2;
    [SerializeField] float plyn3;
    [SerializeField] float plyn4;






    void Start()
    {

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
        basicEmmision = 10f;
        basicSpeed = 2.4f;
        basicLifetime = 0.74f;
        breakForce= 0;
        wheelColliderLeftBack.brakeTorque = breakForce;
        wheelColliderRightBack.brakeTorque = breakForce;



    }

  

    public void InputAssign(InputAction.CallbackContext context)
    {
        
        if (context.performed)
        {
            verticalInput = context.ReadValue<float>();
            


        }
    

        else if (context.canceled)
        {
            verticalInput = context.ReadValue<float>();
            
        }
    
        
       
    }


    void Break()
    {
        breakForce= 300;
        wheelColliderLeftBack.brakeTorque = breakForce;
        wheelColliderRightBack.brakeTorque = breakForce;
        wheelColliderLeftFront.brakeTorque = breakForce;
        wheelColliderRightFront.brakeTorque = breakForce;

        runingAudio.pitch = 1;
        
    }



    void FixedUpdate()
    {
        motorBool = manager.GetComponent<BvpEngine>().motorIsRuning;
        handBrake = manager.GetComponent<BvpEngine>().handBrake;

        if (motorBool == true && verticalInput != 0f && handBrake == false)
        {
       
            
            wheelColliderLeftBack.brakeTorque = 0f;
            wheelColliderRightBack.brakeTorque = 0f;
            wheelColliderLeftFront.brakeTorque = 0f;
            wheelColliderRightFront.brakeTorque = 0f;



            wheelColliderLeftBack.motorTorque = verticalInput * motorTorque;
            wheelColliderRightBack.motorTorque = verticalInput * motorTorque;
            runingAudio.pitch = 1f + Mathf.Abs(verticalInput / 8f);

        }

        else if (motorBool == false)
        {
            Break();

        }

        if (Input.GetKey(KeyCode.C) || handBrake == true)
        {
            Break();


        }
        
        
        wheelColliderLeftFront.steerAngle = Input.GetAxis("Horizontal") * maxSteer;
        wheelColliderRightFront.steerAngle = Input.GetAxis("Horizontal") * maxSteer;




    }



    void Update()
    {
        motorBool = manager.GetComponent<BvpEngine>().motorIsRuning;
        handBrake = manager.GetComponent<BvpEngine>().handBrake;

        if (motorBool == true )
        {
            

            exhaustParticleL.emissionRate = basicEmmision + (Mathf.Abs(verticalInput) * 3f);
            exhaustParticleR.emissionRate = exhaustParticleL.emissionRate;

            exhaustParticleL.startLifetime = basicLifetime + (Mathf.Abs(verticalInput) * 1f);
            exhaustParticleR.startLifetime = exhaustParticleL.startLifetime;

            exhaustParticleL.startSpeed = basicSpeed + (Mathf.Abs(verticalInput) * 1.2f);
            exhaustParticleR.startSpeed = exhaustParticleL.startSpeed;

         }   

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
        
        

       

       brzda1 = wheelColliderLeftBack.brakeTorque;
       brzda2 = wheelColliderRightBack.brakeTorque;
       brzda3 = wheelColliderLeftBack.brakeTorque;
       brzda4 = wheelColliderRightBack.brakeTorque;

       plyn1 = wheelColliderLeftBack.motorTorque;
       plyn2 = wheelColliderRightBack.motorTorque;
       plyn3 = wheelColliderLeftBack.motorTorque;
       plyn4 = wheelColliderRightBack.motorTorque;






    }





}