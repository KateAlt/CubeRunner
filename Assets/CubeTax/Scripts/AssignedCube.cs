using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignedCube : MonoBehaviour
{
    public GameObject objectToDelete; 

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(objectToDelete);
            Debug.Log("Its work+++++++++++++++++++++++++++++++++++++++++");

        }
    }
}
