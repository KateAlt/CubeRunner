using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToDown : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * 30f *  Time.deltaTime);
    }
}
