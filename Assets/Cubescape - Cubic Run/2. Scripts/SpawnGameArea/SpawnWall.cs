// Author: Kateryna Fedenko
// Creation Date: Apr 2024
// License: Creative Commons Attribution-NonCommercial (CC BY-NC)
// Project Link: https://github.com/KateAlt/CubeTax

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace CubicRun.MainGame
{
    ///<summary>
    /// Клас що відповідає за створення перешкод в грі
    ///</summary>
    public class SpawnWall : MonoBehaviour
    {
        public WallData wallData;

        private Material materialWall;
        public GameObject box;

        private int[] positionWalls;

        private void Start()
        {
            positionWalls = SpawnMeneger.positionWallTest;
        }

        private void OnEnable()
        {
            SpawnMeneger.SpawnTracker += CreateWall;
            materialWall = SpawnMeneger.matWall;
        }

        private void OnDisable()
        {
            SpawnMeneger.SpawnTracker -= CreateWall;
        }

        private void PositionOfWall(int[] value) => positionWalls = value;

        ///<summary>
        /// Метод що створює стіни в реальному часі
        ///</summary>
        public void CreateWall(float posZ)
        {
            for (int i = -2; i < 3; i++)
            {
                int num = (int)posZ + i;

                if(positionWalls[num] != 0)
                {
                    Vector2[] wall = wallData.positionOfSpawnWall[positionWalls[num]].wallConstruction;  // (X 2.00,  Y -2.00)

                    foreach(Vector2 numPos in wall)
                    {
                        /// position calculation
                        Vector3 posotionSpawn = new Vector3(numPos.x, numPos.y + 20.0f, num + 20f);
                        Vector3 posotionTarget = new Vector3(numPos.x, numPos.y + 1.0f, num);

                        /// creating an object
                        GameObject objBox = Instantiate(box, posotionSpawn, Quaternion.identity);
                                    objBox.name = posotionTarget.ToString();

                        /// adding material
                        Renderer objBoxRen = objBox.GetComponent<Renderer>();
                                    objBoxRen.material = materialWall;

                        /// adding motion
                        float randomSpeedBox = UnityEngine.Random.Range(20f, 45f);
                        StartCoroutine(MovementHandler.MoveBox(objBox, posotionTarget, randomSpeedBox));
                    }
                }
            }
        }
    }
}
