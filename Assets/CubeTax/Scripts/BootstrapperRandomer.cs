using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BootstrapperRandomer : MonoBehaviour
{
    public MainData mainData;
    public ColorSchemes ColorSchemes;

    public GameObject platformPrefab;
    public GameObject cubePrefab;
    public GameObject coinPrefab;
    public GameObject[] wallPrefabs;
    public GameObject finishCirclePrefab;
    public GameObject finishPlanePrefab;
    public GameObject directionalLightObject;
    public Material yourNewMaterial;

    private Light directionalLight;
    private int numberOfWalls;
    private int[] wallKind;
    private int[] sizeOfSpaces;
    private int totalPlatforms;

    private void Start()
    {
        Initialize();
        Setup();
        InstantiatePlatforms();
        InstantiateCubeAndWall();
        SetDirectionalLightColor();
    }

    private void Initialize()
    {
        directionalLight = directionalLightObject.GetComponent<Light>();
    }

    private void Setup()
    {
        numberOfWalls = Random.Range(mainData.minCountWall, mainData.maxCountWall);

        wallKind = GenerateRandomSpaces(numberOfWalls, 1, wallPrefabs.Length, "wall Kind");
        sizeOfSpaces = GenerateRandomSpaces(numberOfWalls, mainData.minSpace, mainData.maxSpace, "size of spaces");

        totalPlatforms = ((numberOfWalls * 3) / 5) + ((sizeOfSpaces.Sum() * 3) / 5) + 4;
    }

    private int[] GenerateRandomSpaces(int count, int minValue, int maxValue, string text)
    {
        int[] sizes = new int[count];
        sizes[0] = Random.Range(minValue, maxValue);

        for (int i = 1; i < sizes.Length; i++)
        {
            int x = Random.Range(minValue, maxValue);

            if (x != sizes[i - 1])
                sizes[i] = x;
            else
                i--;
        }

        foreach (int size in sizes)
        {
            Debug.Log(size + " " + text);
        }
        return sizes;
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
            InitializeRenderer(newPlatform);
            
            countPositionPlatform++;
            positionKK = Vector3.forward * i * platformSpacing;
        }

        for (int i = 0; i < 3; i++)
        {
            Instantiate(platformPrefab, positionKK + new Vector3(0f, 0f, i * platformSpacing), Quaternion.identity);
        }

        Instantiate(finishCirclePrefab, positionKK + new Vector3(0f, 1.7f, 10f), Quaternion.identity);
        Instantiate(finishPlanePrefab, positionKK + new Vector3(0f, 0.55f, 10f), Quaternion.identity);
    }

    private void InstantiateCubeAndWall()
    {
        float cubeSpacing = 3f;
        float height = 1f;
        int countPosition = 4;

        Instantiate(cubePrefab, new Vector3(0f, 1f, 3f), Quaternion.identity);
        Instantiate(cubePrefab, new Vector3(Random.Range(-2f, 2f), 1f, 6f), Quaternion.identity);

        Instantiate(wallPrefabs[Random.Range(1, wallPrefabs.Length)], new Vector3(0f, 0f, 9f), Quaternion.identity);
        int m = 0;

        foreach (int spaceSize in sizeOfSpaces)
        {
            for (int i = 1; i <= spaceSize; i++)
            {
                int point = Random.Range(0, 3);
                if (point == 0)
                {
                    Vector3 cubePosition = new Vector3(Random.Range(-2f, 2f), height, countPosition * cubeSpacing);
                    GameObject newCube = Instantiate(cubePrefab, cubePosition, Quaternion.identity);
                    countPosition++;
                }
                else if (point == 1)
                {
                    Vector3 cubePosition = new Vector3(Random.Range(-2f, 2f), height, countPosition * cubeSpacing);
                    GameObject newCube = Instantiate(coinPrefab, cubePosition, Quaternion.identity);
                    countPosition++;
                }
                else
                {
                    countPosition++;
                }
            }

            Vector3 wallPosition = new Vector3(0f, 0f, countPosition * cubeSpacing);
            Instantiate(wallPrefabs[wallKind[m]], wallPosition, Quaternion.identity);
            m++;
            countPosition++;
        }
    }

    private void SetDirectionalLightColor()
    {
        directionalLight.color = ColorSchemes.lightOrangeColor;
    }

    private void InitializeRenderer(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        renderer.material = yourNewMaterial;
        renderer.material.color = new Color(1f, 0.6431373f, 0.2039215f);
    }
}
