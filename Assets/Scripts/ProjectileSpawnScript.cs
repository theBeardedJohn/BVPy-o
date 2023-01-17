using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public Rigidbody bvpRb;



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            Shoot();
            KickBack();
        
        }


    }

    void Shoot()
    {
        
        Instantiate(bullet, firePoint.position, firePoint.rotation);


    }

    void KickBack()
    {

        bvpRb.AddRelativeForce(0f, 1000f, 1000f);

    }


}
