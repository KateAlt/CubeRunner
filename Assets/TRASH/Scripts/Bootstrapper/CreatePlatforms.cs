using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatforms : MonoBehaviour
{
    // public void InstantiatePlatforms(Material newMaterial)
    // {
    //     float platformSpacing = 5f;
    //     Vector3 positionKK = Vector3.zero;
    //     int countPositionPlatform = 0;

    //     for (int i = 0; i < totalPlatforms; i++)
    //     {
    //         Vector3 platformPosition = Vector3.forward * i * platformSpacing;
    //         GameObject newPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
    //         Renderer renderer = newPlatform.GetComponent<Renderer>();
    //         renderer.material = newMaterial;
            
    //         countPositionPlatform++;
    //         positionKK = Vector3.forward * i * platformSpacing;
    //     }

    //     for (int i = 0; i < 3; i++)
    //     {
    //         GameObject enemy = Instantiate(platformPrefab, positionKK + new Vector3(0f, 0f, i * platformSpacing), Quaternion.identity);
    //         Renderer renderer = enemy.GetComponent<Renderer>();
    //         renderer.material = newMaterial;
    //         // MeshRenderer enemyMeshRenderer = enemy.GetComponent<MeshRenderer>();

    //         // if (enemyMeshRenderer != null)
    //         // {
    //         //     enemyMeshRenderer.material = mainData.colorsEnvironment[Random.Range(0, mainData.colorsEnvironment.Length)];
    //         //     Debug.Log("its work ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    //         // }
    //         // else{
    //         //     Debug.Log("Renderer = null =========================================");
    //         // }
    //     }

    //     Instantiate(finishCirclePrefab, positionKK + new Vector3(0f, 1.7f, 10f), Quaternion.identity);
    //     Instantiate(finishPlanePrefab, positionKK + new Vector3(0f, 0.55f, 10f), Quaternion.identity);
    // }
}
