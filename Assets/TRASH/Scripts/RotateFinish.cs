using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFinish : MonoBehaviour
{
    void FixedUpdate()
    {
        float rotationSpeed = 30f;

        // Rotate around the X, Y, and Z axes
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // transform.Rotate(Vector3.back * 30f *  Time.deltaTime);
    }
}
