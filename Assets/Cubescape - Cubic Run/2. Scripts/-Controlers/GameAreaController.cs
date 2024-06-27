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
    public class GameAreaController : MonoBehaviour
    {
        #region Fields
        public static int lev;
        public static int plusRating;
        public static int starRating;
        public static int plusRemainingLev;

        public GameObject character;
        public int scorePlus;

        private LevelsData levData;
        private int legthWay;
        private int totalPluses;
        #endregion

        #region Actions
        public static event Action<float> UpdateWayLine;
        public static event Action<int> OnScoreCountChanged;

        public static event Action<int> SetStarRating;
        #endregion

        private void Awake()
        {
            // -- download resources
            levData = Resources.Load<LevelsData>("LevelsData");
            legthWay = levData.lev[levData.levelGame].GetPlatformData();
            totalPluses = levData.lev[levData.levelGame].plusRemaining;

            lev = levData.levelGame;
            scorePlus = 0;
            starRating = 0;
            plusRemainingLev = levData.lev[levData.levelGame].plusRemaining;
        }

        private void FixedUpdate()
        {
            UpdateWayLine?.Invoke(CountLineWay());
            CountStrats();
        }
 
        private float CountLineWay()
        {
            float way = (float)legthWay - 10f;
            return (100f / way) * character.transform.position.z - 7.14f;
        }

        private void CountStrats()
        {
            float result = (100f / (float)totalPluses) * (float)scorePlus;

            if (result > 99f)
                starRating = 3;
            else if (result > 66f)
                starRating = 2;
            else if (result > 33f)
                starRating = 1;

            SetStarRating?.Invoke(starRating);
        }

        public void AddScorePlus(int value)
        {
            scorePlus ++;
            plusRating = scorePlus;
            OnScoreCountChanged?.Invoke(scorePlus);
        }
        private void OnEnable()
        {
            CharacterController.PlusPoint += AddScorePlus;
        }

        private void OnDisable()
        {
            CharacterController.PlusPoint -= AddScorePlus;
        
            if(levData.lev[levData.levelGame].starCount <= starRating)
            {
                levData.lev[levData.levelGame].starCount = starRating;
            }

            if(levData.lev[levData.levelGame].plusCollected <= scorePlus)
            {
                levData.lev[levData.levelGame].plusCollected = scorePlus;
            }
        }
    }
}