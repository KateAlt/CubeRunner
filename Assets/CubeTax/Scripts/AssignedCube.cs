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
            // Destroy(objectToDelete);
            objectToDelete.AddComponent<PlatfonmMechanics>();
            objectToDelete.transform.parent = null;
            MainDate.countCubes -= 1;

            Debug.Log("Add Component PlatfonmMechanics " + "transform parent is null" + objectToDelete.name);
        }
    }
}
