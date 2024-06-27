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
    public class InputHandler
    {
        // Vector2 startPos  = Vector2.zero;
        // Vector2 direction = Vector2.zero;

        // public static event Action<int> Swipe;

        // private void DetectSwipe()
        // {
        //     if (Input.touchCount == 1)
        //     {
        //         Touch touch = Input.GetTouch(0);

        //         switch (touch.phase)
        //         {
        //             case TouchPhase.Began:
        //                 startPos = touch.position;
        //                 break; 

        //             case TouchPhase.Ended:
        //                 direction = touch.position - startPos;

        //                 if (direction.x > 50f)           // Swipe to the right
        //                 {
        //                     DetectTouchs?.Invoke(-1);
        //                     break;   
        //                 }
        //                 if (direction.x < -50f)          // Swipe to the left
        //                 {
        //                     DetectTouchs?.Invoke(1);
        //                     break;   
        //                 }
        //                 break;                    
        //         }
        //     }
    // }
    // }

        // public void DetectPress()
        // {
        //     if (Input.touchCount == 1)
        //     {
        //         Touch touch = Input.GetTouch(0);

        //         switch (touch.phase)
        //         {
        //             case TouchPhase.Began:
        //                 startPos = touch.position;
        //                 break;

        //             case TouchPhase.Ended:

        //                 if(touch.position == startPos)
        //                 {
        //                     // SceneManager.LoadScene("GameArea");
        //                 }
        //                 break;
        //         }
        //     }
        // }
    }
}

                            // levelsData.levelGame --;
                            // menuView.MoveBlockPlatforms(new Vector3(initialPlatforms.transform.position.x + 5f, 0f, 0f), 20.0f);
                            // uiMenuView.UILevelUpdate(levelsData.levelGame);
                            // uiMenuView.UILevDemandUpdate(mainModel, levelsData);
                            // uiMenuView.UIDetectUnlockLevel(mainModel, levelsData);


                            // levelsData.levelGame ++;
                            // menuView.MoveBlockPlatforms(new Vector3(initialPlatforms.transform.position.x - 5f, 0f, 0f), 20.0f);
                            // uiMenuView.UILevelUpdate(levelsData.levelGame);
                            // uiMenuView.UILevDemandUpdate(mainModel, levelsData);
                            // uiMenuView.UIDetectUnlockLevel(mainModel, levelsData);