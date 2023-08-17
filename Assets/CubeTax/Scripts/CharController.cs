using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public MainData MainData;

    public GameObject cubePrefab;
    public Transform parentObject;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Cube"))
        {
            Destroy(collision.gameObject);

            MainData.countCubes += 1;
            GameObject enemy = Instantiate(cubePrefab, new Vector3(0f, MainData.countCubes + 1f, 0f), Quaternion.identity);
                    enemy.transform.SetParent (parentObject.transform, false);

            Debug.Log("cube: " + new Vector3(0f, MainData.countCubes, 0f) + "  " + MainData.countCubes);
        }

        if (collision.CompareTag("Finish"))
        {
            MainData.canStart = false;
            
        }
    }

    void Update()
    {
        if(MainData.countCubes == 0)
        MainData.canStart = false;
    }

    void OnDisable()
    {
         MainData.countCubes = 1;
    }
}
