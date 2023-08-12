using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QarbageRemoval : MonoBehaviour
{
    void CollisionEnter(Collision collision) {
        GameObject otherObject = collision.gameObject;
        Destroy(otherObject);
    }
}
