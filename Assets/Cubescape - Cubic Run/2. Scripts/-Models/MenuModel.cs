// Script Name: MenuController.cs
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
   public class MenuModel
   {  
      private LevelsData levData;

      #region Actions  +--+--+--+--+--+--+--+--+--+--+--+--+--+
      // UI
      public static event Action<int, int> SetTopBar;                  // Event to update ui data of top bar
      public static event Action<string> SetMainTitle;                 // Lev. 01
      public static event Action<int> SetStarRating;                   // ***

      public static event Action<string, string> SetUnblockData;
      public static event Action<string, string> SetDataRating;
      
      public static event Action<Vector3, float> MovePlatforms; 

      public static event Action<string> SetHint;   


      #endregion +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

      public MenuModel()
      {
         levData = Resources.Load<LevelsData>("LevelsData");
         levData.levelGame = 0;
         
         InitTopBar();
         InitWavyBall();
      }

      #region Method of UI -- -- -- -- -- -- -- -- -- -- -- -- 
      /// <summary>
      /// The method initializes event ui data of top bar.
      /// </summary>
      private void InitTopBar() => SetTopBar?.Invoke(LevelsData.coinStar, LevelsData.coinPlus);

      public void InitWavyBall()
      {
         if(levData.GetIsLevelLocked())
         {
            SetMainTitle?.Invoke(string.Format("LEV. {0:00}", levData.levelGame + 1));

            SetStarRating?.Invoke(levData.GetStarData());
            SetDataRating?.Invoke(levData.GetCoinCollected().ToString(), levData.GetCoinRemaining().ToString());

            SetHint?.Invoke("TAP TO START");
         }
         else
         {
            SetMainTitle?.Invoke("<line-height=75%>LEVEL IS LOCKED");

            SetUnblockData?. Invoke(LevelsData.coinStar.ToString(), levData.GetStarRemaining().ToString());
            SetHint?.Invoke("TAP TO UNBLOCK");
         }
      }
      #endregion  -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- 

      public void LevelChange(int num, GameObject platform)
      {
         // score level
         if(levData.levelGame - num <= levData.lev.Length - 1)
            levData.levelGame = levData.levelGame - num;

         // move platforms on scene
         float pos = 5f * num;
         float bordLev = (levData.lev.Length - 1) * - 5;
         Debug.Log(platform.transform.position.x + " " + bordLev);
         
         if(platform.transform.position.x + pos <= 0f && platform.transform.position.x + pos >= bordLev) // -5 < 0
         {
            MovePlatforms?.Invoke(new Vector3(platform.transform.position.x + pos, 0f, 0f), 20.0f);
            InitWavyBall();
         }
      }
   }
}