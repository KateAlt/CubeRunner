using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorOfLevel : MonoBehaviour
{
    public GameObject cubePlatform;

    void Start()
    {
        StartCoroutine(CreateAPlatform());
    }

    IEnumerator CreateAPlatform()
    {
        while (true)
        {
            Instantiate(cubePlatform, new Vector3(0f, 20f, 0f), Quaternion.identity);
            Debug.Log("Its work");
            yield return new WaitForSeconds(2f);
            //djfio
        }
    }
}