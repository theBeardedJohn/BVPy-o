using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            Shoot();
        
        
        }


    }

    void Shoot()
    {
        
        Instantiate(bullet, firePoint.position, firePoint.rotation);


    }




}
