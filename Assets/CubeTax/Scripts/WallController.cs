using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        GameObject otherObject = collision.gameObject;
        Destroy(otherObject.GetComponent<Rigidbody>());
        otherObject.AddComponent<PlatfonmMechanics>();
        otherObject.transform.parent = null;
        MainDate.countCubes -= 1;
        Debug.Log(MainDate.countCubes);
    }
}
