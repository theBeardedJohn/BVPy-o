using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BvpHealth : MonoBehaviour
{
    // Script pro HEALT a PALIVO BVP

    public GameObject bvpDestro;
    public bool motorBool;
    public GameObject manager;

    public float verticalIn;

    // HEALTH SYSTEM
    public Text healthUi;
    public Image healthBarUi;
    public float enemyDmg;
    public float maxHealth;

    private float healthPercentage;
    private float health;

    // FUEL SYSTEM
    public Text fuelUi;
    public Image fuelBarUi;
    public float maxFuel;
    public float fuelConsMult;
    public float fuelConsIdle;
    
    public float fuelPercentage;
    public float fuel;
    private float fuelCons;

    // Nastavení zdraví a paliva na max pøi spuštìní
    private void Start()
    {
        health = maxHealth;
        fuel = maxFuel;

    }

    // Odeèet zdraví pøi kolizi s kulkou a podmínka pro znièení
    private void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Bullet" && health > 1)
        {

            health -= enemyDmg;

        }

        else if (Collision.gameObject.tag == "Bullet" && health <= 1)
        { 
           
            health = 0;

            healthBarUi.fillAmount = 0;
            healthUi.text ="BUSTED";


            Instantiate(bvpDestro, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }



    }

    // Odeèet paliva a podmínka pro motor
    private void FuelConsumption() 
    {
       motorBool = manager.GetComponent<BvpEngine>().motorIsRuning; 
        
        if (motorBool == true)
        {
            verticalIn = GetComponent<BvpMovement>().verticalInput;

            if (verticalIn != 0 && fuel > 0f)
            {
                fuelCons = Mathf.Abs(verticalIn) * fuelConsMult;


            }

            else if (fuel > 0f)
            {
                fuelCons = fuelConsIdle * fuelConsMult;


            }


            if (fuel > 0f)
            {
                fuel -= fuelCons;



            }
            else
                fuel = 0f;

                
                fuelPercentage = fuel / (maxFuel / 100f);

            fuelBarUi.fillAmount = fuelPercentage / 100f;
            fuelUi.text = Mathf.RoundToInt(fuelPercentage).ToString() + "%";
        }



    }

    private void Update()
    {
        FuelConsumption();
        



        healthPercentage = health / (maxHealth / 100f);

        healthBarUi.fillAmount = healthPercentage / 100f;
        healthUi.text = Mathf.RoundToInt(healthPercentage).ToString() + "%";

       




    }
}