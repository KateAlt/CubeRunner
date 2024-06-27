using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDelete : MonoBehaviour
{
    public GameObject inbMeneger;
    void Awake()
    {
    }

    private void OnEnable()
    {
        Instantiate(inbMeneger, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
