using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public MainData MainData;

    public GameObject cubePrefab;
    public Transform parentObject;

    public GameObject uiFall;
    public GameObject uiWin;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Cube"))
        {
            Destroy(collision.gameObject);

            GameObject enemy = Instantiate(cubePrefab, new Vector3(0f, MainData.countCubes + 1f, 0f), Quaternion.identity);
                    enemy.transform.SetParent (parentObject.transform, false);
        }

        if (collision.CompareTag("Finish"))
        {
            MainData.canStart = false;
            uiWin.SetActive(true);
            
        }
    }

    void Update()
    {
        MainData.countCubes = gameObject.transform.childCount - 1;
        if(MainData.countCubes <= 0)
        {
            MainData.canStart = false;
            uiFall.SetActive(true);
        }
    }

    void OnDisable()
    {
        MainData.countCubes = 1;
        MainData.canStart = false;
    }
}
