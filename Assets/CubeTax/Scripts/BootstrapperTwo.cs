using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BootstrapperTwo : MonoBehaviour
{
    public MainData mainData;
    public ColorSchems ColorSchems;

    public int numberOfWalls;

    private int[] sizeOfSpaces;
    
    private int totalPlatforms;

    public GameObject platformPrefab;
    public GameObject cubePrefab;
    public GameObject[] wallPrefabs;
    public GameObject finishCirclePrefab;
    public GameObject finishPlanePrefab;

    public GameObject directionalLightObject;
	private Light directionalLight;

    public Material yourNewMaterial;

    private void Start()
    {
        numberOfWalls = Random.Range(4, 15);
        Setup();
        InstantiatePlatforms();
        InstantiateCubeAndWall();

        directionalLight = directionalLightObject.GetComponent<Light>();
        directionalLight.color = ColorSchems.lightOrangeColor;
    }

    private void Setup()
    {
        sizeOfSpaces = GenerateRandomSpaces(numberOfWalls, 2, 4);
        totalPlatforms = ((numberOfWalls * 3) / 5) + ((sizeOfSpaces.Sum() * 3) / 5) + 4;
    }

    private int[] GenerateRandomSpaces(int count, int minValue, int maxValue)
    {
        int[] sizes = new int[count];

        for (int i = 0; i < count; i++)
        {
            sizes[i] = Random.Range(minValue, maxValue);
        }

        return sizes;
        //! додати перевірку чи не багато співпадінь
    }

    private void InstantiatePlatforms()
    {
        float platformSpacing = 5f;
        Vector3 positionKK = Vector3.zero;
        int countPositionPlatform = 0;

        for (int i = 0; i < totalPlatforms; i++)
        {
            Vector3 platformPosition = Vector3.forward * i * platformSpacing;
            GameObject newPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
            Renderer renderer = newPlatform.GetComponent<Renderer>();
            renderer.material = yourNewMaterial;
            renderer.material.color = new Color(1f, 0.6431373f, 0.2039215f);

            countPositionPlatform ++;
            positionKK = Vector3.forward * i * platformSpacing;
        }

        
        Instantiate(platformPrefab, positionKK, Quaternion.identity);
        Instantiate(platformPrefab, positionKK + new Vector3(0f, 0f, 5f), Quaternion.identity);
        Instantiate(platformPrefab, positionKK + new Vector3(0f, 0f, 10f), Quaternion.identity);

        Instantiate(finishCirclePrefab, positionKK + new Vector3(0f, 1.7f, 10f), Quaternion.identity);
        Instantiate(finishPlanePrefab, positionKK + new Vector3(0f, 0.55f, 10f), Quaternion.identity);
    }

    private void InstantiateCubeAndWall()
    {
        float cubeSpacing = 3f;
        float height = 1f;
        int countPosition = 4;

        Instantiate(cubePrefab, new Vector3(0f, 1f, 3f), Quaternion.identity);
        Instantiate(cubePrefab, new Vector3((float)Random.Range(-2, 2), 1f, 6f), Quaternion.identity);
        
        Instantiate(wallPrefabs[Random.Range(1, wallPrefabs.Length)], new Vector3(0f, 0f, 9f), Quaternion.identity);

        foreach (int spaceSize in sizeOfSpaces)
        {
            for (int i = 1; i <= spaceSize; i++)
            {
                if(Random.Range(0, 2) == 1)
                {
                    Vector3 cubePosition = new Vector3((float)Random.Range(-2, 2), height, countPosition * cubeSpacing);
                    GameObject newPlatform = Instantiate(cubePrefab, cubePosition, Quaternion.identity);
                    Renderer renderer = newPlatform.GetComponent<Renderer>();
                    renderer.material = yourNewMaterial;
                    renderer.material.color = new Color(1f, 0.6431373f, 0.2039215f);
                    countPosition++;
                }
                else
                {
                    Debug.Log("Nothing");
                    countPosition++;
                }
                
            }

            Vector3 wallPosition = new Vector3(0f, 0f, countPosition * cubeSpacing);
            Instantiate(wallPrefabs[Random.Range(1, wallPrefabs.Length)], wallPosition, Quaternion.identity);
            countPosition++;
            Debug.Log(countPosition);
        }
    }

}
