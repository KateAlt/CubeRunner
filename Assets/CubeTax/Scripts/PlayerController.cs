using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cubePrefab;
    // public GameObject UIElem;
    public Transform parentObject;


    private void OnTriggerEnter(Collider other){

        if (other.CompareTag("Cube")){

            GameObject otherObject = other.gameObject;
            Destroy(otherObject);
            MainDate.countCubes += 1;

            GameObject enemy = Instantiate(cubePrefab, new Vector3(0f, MainDate.countCubes, 0f), Quaternion.identity);
                       enemy.transform.SetParent (parentObject.transform, false);

            Debug.Log("cube: " + new Vector3(0f, MainDate.countCubes, 0f) + "  " + MainDate.countCubes);
        }

    }   

    void Update(){
        // if(transform.childCount == 0f){
        //     Debug.Log(transform.childCount);
        //     MainDate.canStart = false;
        //     UIElem.SetActive(true);
        // }
        // ReCountCobe();
    } 

    // void ReCountCobe()
    // {
    //     int childCount = parentObject.childCount;
    //     Debug.Log("ReCountCobe: " + childCount);

    //     for(int i = 0; i < childCount; i++){
            
    //         Transform child = parentObject.GetChild(i);
    //         child.position = new Vector3(0f, (float)i + 0.5f, 0f);
    //     }
    // }
}
