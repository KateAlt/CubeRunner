using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public MainData MainData;
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            MainData.canStart = true;
            Destroy(gameObject);
        }
    }
}
