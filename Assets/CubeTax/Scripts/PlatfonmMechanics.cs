using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfonmMechanics : MonoBehaviour
{
    void FixedUpdate()
    {
        if(true){ //MainDate.canStart
            
            transform.Translate(Vector3.back * MainDate.speedOfMove * Time.deltaTime);

            if(transform.position.z < -6){
                Destroy(gameObject);
            }
        }
    }
}
