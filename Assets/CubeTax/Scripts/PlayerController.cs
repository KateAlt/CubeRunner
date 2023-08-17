// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     public GameObject cubePrefab;
//     // public GameObject UIElem;
//     public Transform parentObject;
//     public MainData MainData;


//     private void OnTriggerEnter(Collider other){

//         if (other.CompareTag("Cube")){

//             GameObject otherObject = other.gameObject;
//             Destroy(otherObject);
//             MainData.countCubes += 1;

//             GameObject enemy = Instantiate(cubePrefab, new Vector3(0f, MainData.countCubes, 0f), Quaternion.identity);
//                        enemy.transform.SetParent (parentObject.transform, false);

//             Debug.Log("cube: " + new Vector3(0f, MainData.countCubes, 0f) + "  " + MainData.countCubes);
//         }

//     }   

//     void Update(){
//         // if(transform.childCount == 0f){
//         //     Debug.Log(transform.childCount);
//         //     MainData.canStart = false;
//         //     UIElem.SetActive(true);
//         // }
//         // ReCountCobe();
//     } 

//     // void ReCountCobe()
//     // {
//     //     int childCount = parentObject.childCount;
//     //     Debug.Log("ReCountCobe: " + childCount);

//     //     for(int i = 0; i < childCount; i++){
            
//     //         Transform child = parentObject.GetChild(i);
//     //         child.position = new Vector3(0f, (float)i + 0.5f, 0f);
//     //     }
//     // }
// }
