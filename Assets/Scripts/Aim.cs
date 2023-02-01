using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;

public class Aim : MonoBehaviour
{

    public Transform barellAnchor;

    float rotationY;
    float rotationX;

    
    [SerializeField] float aimSensitivity;


    private void Start()
    {
        rotationY = 1f;
        rotationX = 1f;
    }





    void AimHorizontal()
    {
        
     
        if (Input.GetKey(KeyCode.J))
        {
            rotationY = -1f * aimSensitivity;

        }

        else if (Input.GetKey(KeyCode.L))
        {
            rotationY = 1f * aimSensitivity;

        }

        transform.Rotate(0f, rotationY, 0f);
    }

    void AimVertical()
    {


        if (Input.GetKey(KeyCode.I))
        {
            rotationX = -1f * aimSensitivity;

        }

        else if (Input.GetKey(KeyCode.K))
        {
            rotationX = +1f * aimSensitivity;

        }

        barellAnchor.transform.Rotate(rotationX, 0f, 0f, Space.Self);
    }







    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.J))
        {
            AimHorizontal();

        }

        else if (Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.I))
        {
            AimVertical();

        }


        


    }
}

