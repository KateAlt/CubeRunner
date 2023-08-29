// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class RandomizerController : MonoBehaviour
// {
//     public MainData mainData;

//     public GameObject platformPrefab;
//     public GameObject[] wallPrefabs;

//     // private int numberOfWalls;
//     public int[] sizeOfSpaces;

//     public void InitializeRandomLevel()
//     {
//         int numberOfWalls = Random.Range(mainData.minCountWall, mainData.maxCountWall);
//         sizeOfSpaces = GenerateRandomSpaces(numberOfWalls, mainData.minSpace, mainData.maxSpace);
//         int[] wallKind;
//     }

//     private int[] GenerateRandomSpaces(int count, int minValue, int maxValue)
//     {
//         int[] sizes = new int[count];

//         for (int i = 0; i < count; i++)
//             sizes[i] = Random.Range(minValue, maxValue);

//         for(int i = 0; i < sizes.Length - 1; i++)
//         {
//             if (sizes[i] == sizes[i + 1])
//             {
//                 sizes[i] = Random.Range(minValue, maxValue);
//             }
//         }
//         return sizes;
//     }

//     public List<ArreyObjects> objects = new List<ArreyObjects>();

//     public List<ArreyObjects> RandomizeWalls()
//     {
        
//         for (int i = 0; i < 10; i++)
//         {
//             AddObject("Wall");
//         }

//         return objects;

//     }

//     private void AddObject(string kindObj )
//     {
//         ArreyObjects newObj = new ArreyObjects();

//         newObj.kindObject = kindObj;
//         newObj.position = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
//         newObj.numInstance = Random.Range(1, 4);

//         objects.Add(newObj);
//     }
// }

// public class ArreyObjects
// {
//     public string kindObject;
//     public Vector3 position;
//     public int numInstance;
// }

// // newObj.kindObject = "Wall";
// // newObj.position = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
// // newObj.numInstance = Random.Range(1, 4);