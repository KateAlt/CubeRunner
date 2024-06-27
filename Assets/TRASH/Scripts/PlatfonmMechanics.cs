using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfonmMechanics : MonoBehaviour
{
    public MainData mainData;

    void FixedUpdate()
    {
        if(mainData.canStart)
        { 
            transform.Translate(Vector3.back * mainData.speedOfMove * Time.deltaTime);

            if(transform.position.z < -7){
                Destroy(gameObject);
            }
        }
    }
}
