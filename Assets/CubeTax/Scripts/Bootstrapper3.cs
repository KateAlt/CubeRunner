using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper3 : MonoBehaviour
{
    public InstantiateController instantiateController;

    public DataLevels Level1;

    void Start()
    {
        instantiateController.InstantiatePlatforms(Level1.numberOfPlatforms);
        instantiateController.InstantiateCubes(Level1.cubes);
        instantiateController.InstantiateWalls(Level1.walls);
    }
}
