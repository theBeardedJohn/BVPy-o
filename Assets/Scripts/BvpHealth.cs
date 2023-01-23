using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BvpHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bvpDestro;


    private void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Bullet")
        {

            Instantiate(bvpDestro, transform.position, transform.rotation);
            Destroy(gameObject);

            Debug.Log("Its HIT!!");

        }


    }

}