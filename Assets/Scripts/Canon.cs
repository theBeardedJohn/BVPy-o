using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public Transform playerTrans;
    public Transform canonBase;
    public Transform canonBarel;


 

    [SerializeField] float distance;




    void Update()
    {

        //distance = Vector3.Distance(playerTrans.position, canonBase.position);

        canonBase.LookAt(new Vector3(playerTrans.position.x, canonBase.position.y, playerTrans.position.z));
        canonBarel.LookAt(playerTrans);

       



    }
}
