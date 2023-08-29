// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class InstantiateController : MonoBehaviour
// {
//     public GameObject platformPrefab;
//     public GameObject cubePrefab;
//     public GameObject[] wallPrefabs;

//     public GameObject finishCirclePrefab;
//     public GameObject finishPlanePrefab;

//     public Material yourNewMaterial;
//     public GameObject directionalLightObject;

//     private int totalPlatforms;
//     private int[] sizeOfSpaces;

//     private void Start()
//     {
//         RandomizerController randomizer = GetComponent<RandomizerController>();
//         totalPlatforms = ((randomizer.numberOfWalls * 3) / 5) + ((randomizer.sizeOfSpaces.Length * 3) / 5) + 4;

//         InstantiatePlatforms();
//         InstantiateCubeAndWall();
//     }

//     private void InstantiatePlatforms()
//     {
//         // Implement your platform instantiation logic here
//     }

//     private void InstantiateCubeAndWall()
//     {
//         // Implement your cube and wall instantiation logic here
//     }
// }
