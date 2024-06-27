using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BootstrapperRandomer : MonoBehaviour
{
    public MainData mainData;

    public GameObject platformPrefab;
    public GameObject cubePrefab;
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

    public Material newMaterial;

    private void Start()
    {
        // Setup();
        // InstantiatePlatforms();
        InstantiateCubeAndWall();
    }

    // private void Setup()
    // {
    //     numberOfWalls = Random.Range(mainData.minCountWall, mainData.maxCountWall);

    //     wallKind = GenerateRandomSpaces(numberOfWalls, 1, wallPrefabs.Length, "wall Kind");
    //     sizeOfSpaces = GenerateRandomSpaces(numberOfWalls, mainData.minSpace, mainData.maxSpace, "size of spaces");

    //     totalPlatforms = ((numberOfWalls * 3) / 5) + ((sizeOfSpaces.Sum() * 3) / 5) + 4;
    // }

    // private int[] GenerateRandomSpaces(int count, int minValue, int maxValue, string text)
    // {
    //     int[] sizes = new int[count];
    //     sizes[0] = Random.Range(minValue, maxValue);

    //     for (int i = 1; i < sizes.Length; i++)
    //     {
    //         int x = Random.Range(minValue, maxValue);

    //         if (x != sizes[i - 1])
    //             sizes[i] = x;
    //         else
    //             i--;
    //     }

    //     foreach (int size in sizes)
    //     {
    //         Debug.Log(size + " " + text);
    //     }
    //     return sizes;
    // }

    // public void InstantiatePlatforms()
    // {
    //     float platformSpacing = 5f;                            // Set the spacing between platforms
    //     Vector3 positionPlatform = Vector3.zero;               // Initialize the starting position
    //     int countPositionPlatform = 0;                         // Counter to keep track of the platform positions

    //     for (int i = 0; i < totalPlatforms; i++)               // Loop through the total number of platforms
    //     {
    //         Vector3 platformPosition = Vector3.forward * i * platformSpacing;                                // Calculate the position for the current platform
    //         GameObject newPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);     // Instantiate a new platform at the calculated position with no rotation

    //         Renderer renderer = newPlatform.GetComponent<Renderer>();      // Set the material of the platform
    //         renderer.material = mainData.colorsEnvironment[Random.Range(0, mainData.colorsEnvironment.Length)];
            
    //         countPositionPlatform++;                                       // Increment the platform position counter
    //         positionPlatform = Vector3.forward * i * platformSpacing;      // Update the last platform position
    //     }

    //     Instantiate(finishPlanePrefab, positionPlatform + new Vector3(0f, 0.55f, 10f), Quaternion.identity); // Instantiate a finish plane above the last platform
    //     Instantiate(finishCirclePrefab, positionPlatform + new Vector3(0f, 1.7f, 10f), Quaternion.identity); // Instantiate a finish circle above the last platform
    // }


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
                else
                {
                    countPosition++;
                }
            }

            Vector3 wallPosition = new Vector3(0f, 0f, countPosition * cubeSpacing);
            GameObject newWall = Instantiate(wallPrefabs[wallKind[m]], wallPosition, Quaternion.identity);
            // newWall.GetComponent<Renderer>().material = newMaterial;
            m++;
            countPosition++;
        }
    }
}
