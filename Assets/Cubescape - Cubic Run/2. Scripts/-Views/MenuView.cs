// Author: Kateryna Fedenko
// Creation Date: Apr 2024
// License: Creative Commons Attribution-NonCommercial (CC BY-NC)
// Project Link: https://github.com/KateAlt/CubeTax

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubicRun.MainGame
{
    public class MenuView : MonoBehaviour
    {
        private GameObject blockPlatforms;
        private MainModel mainModel;


        public void Initialize(MainModel model)
        {
            mainModel = model;
        }

        private void Awake()
        {
            blockPlatforms = GameObject.Find("PlatformsMenu");
        }
        
        private void OnEnable()
        {
            MenuModel.MovePlatforms += MoveBlockPlatforms;
        }

        private void OnDisable()
        {
            MenuModel.MovePlatforms -= MoveBlockPlatforms;
        }

        public void MoveBlockPlatforms(Vector3 targetPos, float speed)
        {
            StartCoroutine(MoveBox(blockPlatforms, targetPos, speed));
        }

        public IEnumerator MoveBox(GameObject obj, Vector3 targetPos, float speed)
        {
            while (obj.transform.position != targetPos)
            {
                obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetPos, speed * Time.deltaTime);
                if (obj.transform.position == targetPos)
                {
                    yield break;
                }
                yield return null;
            }
        }
    }
}