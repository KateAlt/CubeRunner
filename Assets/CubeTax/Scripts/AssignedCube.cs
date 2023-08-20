using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignedCube : MonoBehaviour
{
    public GameObject objectToDelete;
    public MainData MainData;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Wall"))
        {
            objectToDelete.GetComponent<PlatfonmMechanics>().enabled = true;
            objectToDelete.transform.parent = null;
        }
    }
}
