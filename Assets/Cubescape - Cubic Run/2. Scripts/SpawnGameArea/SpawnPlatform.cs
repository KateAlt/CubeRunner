// Author: Kateryna Fedenko
// Creation Date: Apr 2024
// License: Creative Commons Attribution-NonCommercial (CC BY-NC)
// Project Link: https://github.com/KateAlt/CubeTax

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubicRun.MainGame
{   
    ///<summary>
    /// Клас що відповідає за створення платформ в грі
    ///</summary>
    public class SpawnPlatform : MonoBehaviour
    {
        public GameObject box;
        private Material[] materialPlutform;

        public float randomSpeedBox;

        private Coroutine currentCoroutine;

        private void OnEnable()
        {
            SpawnMeneger.CreateFirstPlatforms += SpawnStartPlatform;
            SpawnMeneger.SpawnTracker += CreatePlatform;

            materialPlutform = SpawnMeneger.matPlatform;
        }

        private void OnDisable()
        {
            SpawnMeneger.CreateFirstPlatforms -= SpawnStartPlatform;
            SpawnMeneger.SpawnTracker -= CreatePlatform;
        }

        ///<summary>
        /// Метод що спаунить блок з меню на якому стоїть гравець
        ///</summary>
        public void SpawnStartPlatform(GameObject platform)
        {
            GameObject platformObject = Instantiate(platform, new Vector3(0.0f, 0.0f, 5.0f), Quaternion.identity);
        }

        ///<summary>
        /// Метод що створює платформи, з центрами posZ 
        ///</summary>
        public void CreatePlatform(float posZ)
        {
            // Debug.Log(currentCoroutine);
            for( int i = -2; i < 3; i++ )
            {
            
                Material randomMaterialBox = materialPlutform[UnityEngine.Random.Range(0, materialPlutform.Length)];

                for( int j = -2; j < 3; j++ )
                {
                    /// position calculation
                    Vector3 posSpawn = new Vector3(0.0f, 0.0f, 0.0f);
                    posSpawn.x = (float)j;
                    posSpawn.y = 20.0f;
                    posSpawn.z = posZ + 10f - (float)i;

                    /// creating an object
                    GameObject objBox = Instantiate(box, posSpawn, Quaternion.identity);
                               objBox.name = new Vector3((float)j, 0.0f, (float)i + posZ).ToString();

                    /// adding material
                    Renderer objBoxRen = objBox.GetComponent<Renderer>();
                             objBoxRen.material = randomMaterialBox;

                    /// adding motion
                    float randomSpeedBox = UnityEngine.Random.Range(20f, 45f);
                    currentCoroutine = StartCoroutine(MovementHandler.MoveBox(objBox, new Vector3((float)j, 0.0f, (float)i + posZ), randomSpeedBox));
                }
            }
        }
    }
}
