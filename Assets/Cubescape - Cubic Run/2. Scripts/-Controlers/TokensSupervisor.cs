// Script Name: RatingController.cs
// Author: Kateryna Fedenko
// Creation Date: Apr 2024
// License: Creative Commons Attribution-NonCommercial (CC BY-NC)
// Project Link: https://github.com/KateAlt/CubeTax

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubicRun.MainGame
{
    public class TokensSupervisor : MonoBehaviour
    {
        private LevelsData levData;

        private void Awake()
        {
            levData = Resources.Load<LevelsData>("LevelsData");
            
            LevelsData.coinStar = CountComonStar();
            LevelsData.coinPlus = CountComonPlus();
        }

        private int CountComonStar()
        {
            int value = 0;

            for(int i = 0; i < levData.lev.Length; i ++)
            {
                value = value + levData.lev[i].starCount;
            }
            return value;
        }

        private int CountComonPlus()
        {
            int value = 0;

            for(int i = 0; i < levData.lev.Length; i ++)
            {
                value = value + levData.lev[i].plusCollected;
            }
            return value;
        }
    }
}