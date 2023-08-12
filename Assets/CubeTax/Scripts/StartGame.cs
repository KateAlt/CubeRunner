using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(0)){
            
            MainDate.canStart = true;
            Destroy(gameObject);
        }
    }
}
