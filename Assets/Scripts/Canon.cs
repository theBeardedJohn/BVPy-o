using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public Transform playerTrans;
    public Transform canonBase;
    public Transform canonBarel;
    public Transform aimRef;
    private Vector3 lookatRot;

    private float lookatRotVertical;
    private float lookatRotHorizontal;
    private Quaternion aimRefQuat;



    void Start()
    {
        
    }

   
    void Update()
    {
        
        aimRef.transform.LookAt(playerTrans);
        aimRefQuat= aimRef.rotation;

        lookatRotHorizontal = aimRefQuat.y;
        lookatRotVertical = aimRefQuat.x;



        canonBase.Rotate()
        //canonBase.Rotate(lookatRotHorizontal);




        Debug.Log(aimRef.rotation);
    }
}
