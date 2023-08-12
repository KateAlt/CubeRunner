using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriger : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform parentObject;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Cube"))
        {
            Destroy(collision.gameObject);

            MainDate.countCubes += 1;
            GameObject enemy = Instantiate(cubePrefab, new Vector3(0f, MainDate.countCubes + 1f, 0f), Quaternion.identity);
                    enemy.transform.SetParent (parentObject.transform, false);

            Debug.Log("cube: " + new Vector3(0f, MainDate.countCubes, 0f) + "  " + MainDate.countCubes);
            ///dshcfjkdhnfcj
        }
    }
}
