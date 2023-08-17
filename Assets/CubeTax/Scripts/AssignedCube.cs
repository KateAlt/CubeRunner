using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignedCube : MonoBehaviour
{
    public GameObject objectToDelete;
    public MainData MainData;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Destroy(objectToDelete);
            // objectToDelete.AddComponent<PlatfonmMechanics>();
            objectToDelete.GetComponent<PlatfonmMechanics>().enabled = true;
            objectToDelete.transform.parent = null;
            MainData.countCubes -= 1;
        }
    }
}
