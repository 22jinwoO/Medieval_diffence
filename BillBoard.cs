using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.forward = Vector3.forward;

        //Vector3 dir = Camera.main.transform.position - transform.position;


        //Quaternion rot = Quaternion.LookRotation(new Vector3(Camera.main.transform.rotation.x,transform.rotation.y,transform.rotation.z));

        //transform.rotation = rot;
    }
}
