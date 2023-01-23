using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonProjectileSpawnScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
   



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            Shoot();
            
        
        }


    }

    void Shoot()
    {
        
        Instantiate(bullet, firePoint.position, firePoint.rotation);


    }

   


}
