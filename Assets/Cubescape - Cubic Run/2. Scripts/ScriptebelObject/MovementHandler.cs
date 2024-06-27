// Author: Kateryna Fedenko
// Creation Date: Apr 2024
// License: Creative Commons Attribution-NonCommercial (CC BY-NC)
// Project Link: https://github.com/KateAlt/CubeTax

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubicRun.MainGame
{
    public class MovementHandler : MonoBehaviour
    {

        public static IEnumerator MoveBox(GameObject obj, Vector3 targetPos, float speed)
        {
            // Debug.Log("carutine work");

            while (obj.transform.position != targetPos)
            {
                // Debug.Log("LevelsData.isPaused " + LevelsData.isPaused);

                if (!LevelsData.isPaused)
                {
                    // Debug.Log(!LevelsData.isPaused);
                    obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetPos, speed * Time.deltaTime);
                }
                if (obj.transform.position == targetPos)
                {
                    yield break;
                }
                yield return null;
            }
        }
    }
}