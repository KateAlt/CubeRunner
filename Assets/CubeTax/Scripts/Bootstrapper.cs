using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bootstrapper : MonoBehaviour
{
    public TioList LevelsData;
    public GameObject platformPrefab;
    public GameObject cubePrefab;

    public GameObject wall1Prefab;
    public GameObject wall2Prefab;
    public GameObject wall3Prefab;

    private void Start()
    {
        InstantiatePlatforms();
        InstantiateCubes();
        InstantiateWall();
        // InstantiateFinish();
    }

    private void InstantiatePlatforms()
    {
        for (int i = 0; i < LevelsData.numberOfPlatforms; i++)
        {
            Vector3 platformPosition = new Vector3(0f, 0f, i * 5f);
            Instantiate(platformPrefab, platformPosition, Quaternion.identity);
        }
    }

    private void InstantiateCubes()
    {
        for (int i = 0; i < LevelsData.casesCube.Length; i++)
        {
            Instantiate(cubePrefab, LevelsData.casesCube[i].position, Quaternion.identity);
        }
    }

    private void InstantiateWall()
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

    // private void InstantiateFinish()
    // {
    //     Instantiate(cubePrefab, LevelsData.casesCube[i].position, Quaternion.identity);
    // }
}
