using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateController : MonoBehaviour
{
    public MainData mainData;

    public GameObject platformPrefab;
    public GameObject cubePrefab;

    public GameObject finishCirclePrefab;
    public GameObject finishPlanePrefab;

    public void InstantiatePlatforms(int numberOfPlatforms)
    {
        float platformSpacing = 5f;
        int countPositionFinish = 0; // Start counting from 0

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            Vector3 platformPosition = new Vector3(0f, 0f, i * platformSpacing);
            Instantiate(platformPrefab, platformPosition, Quaternion.identity);
            countPositionFinish++;
        }

        float finishOffset = (countPositionFinish * platformSpacing) - 5f;
        Vector3 finishCirclePosition = new Vector3(0f, 1.7f, finishOffset);
        Vector3 finishPlanePosition = new Vector3(0f, 0.55f, finishOffset);

        Instantiate(finishCirclePrefab, finishCirclePosition, Quaternion.identity);
        Instantiate(finishPlanePrefab, finishPlanePosition, Quaternion.identity);
    }

    public void InstantiateCubes(PositionOfCube[] cubes)
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            Instantiate(cubePrefab, cubes[i].position, Quaternion.identity);
        }
    }

    private void InstantiateWall(PositionOfWall[] walls)
    {
        for (int i = 0; i < LevelsData.casesWall.Length; i++)
        {
            switch (LevelsData.casesWall[i].parameterWall)
            {
                case ParameterWall.wallType1:
                    Instantiate(wall1Prefab, LevelsData.casesWall[i].position, Quaternion.identity);
                    break;

                case ParameterWall.wallType2:
                    Instantiate(wall2Prefab, LevelsData.casesWall[i].position, Quaternion.identity);
                    break;

                case ParameterWall.wallType3:
                    Instantiate(wall3Prefab, LevelsData.casesWall[i].position, Quaternion.identity);
                    break;
            }
        }
    }



}
