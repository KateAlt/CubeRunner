using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfonmMechanics : MonoBehaviour
{
    public MainData MainData;

    void FixedUpdate()
    {
        if(MainData.canStart)
        { 
            transform.Translate(Vector3.back * MainData.speedOfMove * Time.deltaTime);

            if(transform.position.z < -7){
                Destroy(gameObject);
            }
        }
    }
}
