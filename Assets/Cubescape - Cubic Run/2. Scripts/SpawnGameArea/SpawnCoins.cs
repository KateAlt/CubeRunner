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
    /// Клас що відповідає за створення монет в грі
    ///</summary>
    public class SpawnCoins : MonoBehaviour
    {
        public Material shineMat;
        public GameObject box;
        public int[] positionCoin;

        private void Start()
        {
            positionCoin = SpawnMeneger.positionCoinTest;
        }

        private void OnEnable()
        {
            SpawnMeneger.SpawnTracker += CreateCoin;
        }

        private void OnDisable()
        {
            SpawnMeneger.SpawnTracker -= CreateCoin;
        }

        ///<summary>
        /// Метод що створює стіни в реальному часі
        ///</summary>
        public void CreateCoin(float posZ)
        {
            for (int i = -2; i < 3; i++)
            {
                int num = (int)posZ + i;
                // Debug.Log("positionCoin[num] " + positionCoin[num]);

                if(positionCoin[num] != 999)
                {
                    /// position calculation
                    Vector3 posotionSpawn = new Vector3(positionCoin[num], 20.0f, num + 20f);
                    Vector3 posotionTarget = new Vector3(positionCoin[num], 1.0f, num);

                    /// creating an object
                    GameObject objBox = Instantiate(box, posotionSpawn, Quaternion.identity);
                                objBox.name = posotionTarget.ToString();

                    /// adding material
                    Renderer objBoxRen = objBox.GetComponent<Renderer>();
                                objBoxRen.material = shineMat;

                    /// adding motion
                    float randomSpeedBox = UnityEngine.Random.Range(20f, 45f);
                    StartCoroutine(MovementHandler.MoveBox(objBox, posotionTarget, randomSpeedBox));

                }
            }
        }
    }
}