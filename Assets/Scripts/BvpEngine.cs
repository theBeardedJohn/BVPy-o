using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




using UnityEngine.Animations;



public class BvpEngine : MonoBehaviour
{

    public Color engineLedColorOn;
    public Color engineLedColorOff;

    // ** SHAKE VAR
    public GameObject bvpTrans;
    public Rigidbody bvpRb;
    [SerializeField] float startShakeSpeed;
    [SerializeField] float shakeAmount;
    
    private bool motorShake;
    public float fuel;
    
    

    public Image engineLed;

   
    public bool motorIsRuning;


    public ParticleSystem startParticlesL;
    public ParticleSystem startParticlesR;

    public Toggle engineButtonTog;

    void Start()
    {
        engineLed.color = engineLedColorOff;
        motorShake = false;
        motorIsRuning = false;

        startParticlesL.Stop();
        startParticlesR.Stop();

    }


    public void MotorSwitch(bool toggleEngine)
    {
       
        if (toggleEngine && fuel > 0f )
        {
            // **STARTOVACI SEKVENCE**
            
            Debug.Log("Startovací sekvence zapoèala - brm brm");
            motorShake = true;
            motorIsRuning = false;
            

            // PARTICLES ON START
            startParticlesL.Play();
            startParticlesR.Play();
            //startParticlesL.startSpeed = 500f;
            //startParticlesR.startSpeed = startParticlesL.startSpeed;




            Invoke("RuningEngine", 3);

        }
    else
        {
            StopEngine();

        }


    }


    private void StopEngine()
    {
        Debug.Log("NEJEDE");
        CancelInvoke("RuningEngine");
        engineLed.color = engineLedColorOff;
        motorShake = false;
        motorIsRuning = false;

        // PARTICLES ON STOP
        startParticlesL.Stop();
        startParticlesR.Stop();
    }



    private void RuningEngine()
    {
        if (fuel > 0f)

        {
            engineLed.color = engineLedColorOn;
            Debug.Log("Jede stabilne");
            motorShake = false;
            motorIsRuning = true;
        }



    }


    


   

   
    void FixedUpdate()
    {
        

        if (motorShake == true) 
        {

            bvpRb.AddRelativeForce(new Vector3(0f, Random.Range(-10000.0f, 10000.0f), Random.Range(-10000.0f, 10000.0f)));
            
        }


    }


    private void Update()
    {
        fuel = bvpTrans.GetComponent<BvpHealth>().fuel;
        if (fuel < 0f)
        {
            StopEngine();
        }


    }



}
