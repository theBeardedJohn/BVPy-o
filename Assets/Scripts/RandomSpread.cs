using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpread : MonoBehaviour
{
    // Random spread pro výbuch - prirazuje se pro kazdou castici zvlast
    private Rigidbody _rb;
    private float min = -500;
    private float max = 500;

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>(); 
        _rb.AddRelativeForce(new Vector3(Random.Range(min, max), Random.Range(min, max), 0f));

    }




}
