using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BvpEngine : MonoBehaviour
{

    public Color engineLedColorOn;
    public Color engineLedColorOff;

   

    public Image engineLed;

   
    public bool motorIsRuning;
    public bool shit;

    private void Start()
    {
        motorIsRuning= false;
    }


    private void MotorSwitch()
    { 
    
       if (Input.GetKeyDown(KeyCode.P)) 
        {
            motorIsRuning = !motorIsRuning;

        Debug.Log(motorIsRuning);
        }

    
    }

    private void StartEngine()
    { 
   
        engineLed.color = engineLedColorOn;
    }

    private void StopEngine()
    {

        engineLed.color = engineLedColorOff;

    }

    private void ShakeEngine() 
    {
    
    
    
    }


   
    void Update()
    {
        MotorSwitch();

        if (motorIsRuning == true)
        {
            StartEngine();


        }
        else
        {
            StopEngine();
        
        }

        

    }
}
