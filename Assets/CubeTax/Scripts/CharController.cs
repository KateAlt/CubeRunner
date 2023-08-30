using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public MainData mainData;

    public GameObject cubePrefab;
    public Transform parentObject;

    public GameObject uiFall;
    public GameObject uiWin;

    void Start()
    {
        StartCoroutine(ReStartData()); // Запускаємо корутину
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Cube"))
        {
            Destroy(collision.gameObject);

            GameObject enemy = Instantiate(cubePrefab, new Vector3(0f, mainData.countCubes + 1f, 0f), Quaternion.identity);
                    enemy.transform.SetParent (parentObject.transform, false);
        }

        if (collision.CompareTag("Finish"))
        {
            mainData.canStart = false;
            uiWin.SetActive(true);
            
        }

        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            mainData.countCoin ++;
        }
    }

    void Update()
    {
        mainData.countCubes = gameObject.transform.childCount - 1;
        if(mainData.countCubes <= 0)
        {
            mainData.canStart = false;
            uiFall.SetActive(true);
        }
    }
    IEnumerator ReStartData()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            mainData.speedOfMove += 0.1f;
        }
    }

    void OnDisable()
    {
        mainData.speedOfMove = 7f;
        mainData.mainCountCoin += mainData.countCoin;
        mainData.countCoin = 0;
        mainData.countCubes = 0;
        mainData.canStart = false;
    }
}
