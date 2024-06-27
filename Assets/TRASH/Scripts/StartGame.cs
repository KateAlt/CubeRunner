using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public MainData MainData;
    public UIController uIController;

    void Update()
    {
        if (Input.GetMouseButton(0)){
            
            MainData.canStart = true;
            uIController.StartCountSpeed();
            Destroy(gameObject);
        }
    }
    
    
}
