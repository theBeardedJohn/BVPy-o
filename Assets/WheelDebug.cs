using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelDebug : MonoBehaviour
{
    public WheelCollider wh1;
    public WheelCollider wh2;
    public WheelCollider wh3;
    public WheelCollider wh4;

    public float rpm1;
    public float rpm2;
    public float rpm3;
    public float rpm4;

    void Update()
    {

        rpm1 = wh1.rpm;
        rpm2 = wh2.rpm;
        rpm3 = wh3.rpm;
        rpm4 = wh4.rpm;




    }
}
