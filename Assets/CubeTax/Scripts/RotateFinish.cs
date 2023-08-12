using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFinish : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(Vector3.back * 30f *  Time.deltaTime);
    }
}
