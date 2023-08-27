using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelCalculation : MonoBehaviour
{
    public MainData mainData;
    private int numberOfWalls;
    private int[] sizeOfSpaces;
    private int totalPlatforms;


    public GameObject platformPrefab;
    public Material yourNewMaterial;
    private void Start()
    {
        GenerateRandoms();
        InstantiatePlatforms();
    }

    //?-------------------------------------------------------------------

    private void GenerateRandoms()
    {
        numberOfWalls = RandomizeWallCount(mainData.minNumberWall, mainData.maxNumberWall);         // generate number of walls in scene
        sizeOfSpaces = RandomizeSpaceCount(numberOfWalls, mainData.minSpace, mainData.maxSpace);   // generate number of 
        totalPlatforms = ((numberOfWalls * 3) / 5) + ((sizeOfSpaces.Sum() * 3) / 5) + 4;
        Debug.Log(numberOfWalls);
    }

    private int RandomizeWallCount(int minValue, int maxValue)
    {
        return Random.Range(minValue, maxValue);
    }

    private int[] RandomizeSpaceCount(int count, int minValue, int maxValue)
    {
        int[] sizes = new int[count];
        for (int i = 0; i < count; i++){
            sizes[i] = Random.Range(minValue, maxValue);
        }
        return sizes;
    }



    private void InstantiatePlatforms()
    {
        Init(platformPrefab, totalPlatforms);
    }

    void Init(GameObject obj, int count)
    {
        float platformSpacing = 5f;
        Vector3 positionKK = Vector3.zero;
        int countPositionPlatform = 0;

        for (int i = 0; i < count; i++)
        {
            Vector3 platformPosition = Vector3.forward * i * platformSpacing;
            GameObject newPlatform = Instantiate(obj, platformPosition, Quaternion.identity);
            Renderer renderer = newPlatform.GetComponent<Renderer>();
            renderer.material = yourNewMaterial;
            renderer.material.color = new Color(0.2509804f, 0.8f, 0.5921569f, 1f);

            countPositionPlatform ++;
            positionKK = Vector3.forward * i * platformSpacing;
        }
    }
}
