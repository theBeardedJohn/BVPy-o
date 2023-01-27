using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BvpHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bvpDestro;
    public bool engine;





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
    
    private float fuelPercentage;
    private float fuel;
    private float fuelCons;


    private void Start()
    {
        health = maxHealth;
        fuel = maxFuel;

    }

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

    private void FuelConsumption() 
    { 
        if (Input.GetAxis("Vertical") != 0)
        {
            fuelCons = Mathf.Abs(Input.GetAxis("Vertical")) * fuelConsMult;
            

        }

        else
        { 
        fuelCons = fuelConsIdle * fuelConsMult;


        }

        fuel -= fuelCons;
        fuelPercentage = fuel / (maxFuel / 100f);

        fuelBarUi.fillAmount = fuelPercentage / 100f;
        fuelUi.text = Mathf.RoundToInt(fuelPercentage).ToString() + "%";




    }

    private void Update()
    {
        FuelConsumption();




        healthPercentage = health / (maxHealth / 100f);

        healthBarUi.fillAmount = healthPercentage / 100f;
        healthUi.text = Mathf.RoundToInt(healthPercentage).ToString() + "%";

       




    }
}