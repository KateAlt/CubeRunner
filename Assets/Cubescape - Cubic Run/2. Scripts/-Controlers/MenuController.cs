// Script Name: MenuController.cs
// Author: Kateryna Fedenko
// Creation Date: Apr 2024
// License: Creative Commons Attribution-NonCommercial (CC BY-NC)
// Project Link: https://github.com/KateAlt/CubeTax

using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the menu functionality including swipe gestures and scene transitions. 
/// </summary>
namespace CubicRun.MainGame
{
    public class MenuController : MonoBehaviour
    {
        #region Fields
        [SerializeField] public GameObject menuPlatforms;
        private LevelsData levData;

        private MenuModel menuModel;

        Vector2 startPos  = Vector2.zero;
        Vector2 direction = Vector2.zero;

        public static event Action<int> DetectTouchs;

        #endregion

        #region Mono
        
        private void OnEnable()
        {
            DetectTouchs += UU;
        }

        private void OnDisable()
        {
            DetectTouchs -= UU;
        }

        private void Start()
        {
            menuModel = new MenuModel();
            levData = Resources.Load<LevelsData>("LevelsData");            
        }

        private void Update()
        {
            DetectSwipe();
            DetectPress();
        }
        #endregion

        #region Methods

        private void UU(int num)
        {
            menuModel.LevelChange(num, menuPlatforms);
        }

        #endregion

        private void DetectSwipe()
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        startPos = touch.position;
                        break; 

                    case TouchPhase.Ended:
                        direction = touch.position - startPos;

                        if (direction.x > 50f)           // Swipe to the right
                        {
                            DetectTouchs?.Invoke(1);
                            break;   
                        }
                        if (direction.x < -50f)          // Swipe to the left
                        {
                            DetectTouchs?.Invoke(-1);
                            break;   
                        }
                        break;                    
                }
            }
        }

        public void DetectPress()
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        startPos = touch.position;
                        break;

                    case TouchPhase.Ended:

                        if(touch.position == startPos)
                        {
                            if(levData.lev[levData.levelGame].isLockLev)
                            {
                                SceneManager.LoadScene("GameArea");
                                // Debug.Log();
                            }
                            else
                            {
                                if(LevelsData.coinStar >= levData.lev[levData.levelGame].starRemaining)
                                {
                                    levData.lev[levData.levelGame].isLockLev = true;
                                }

                                menuModel.InitWavyBall();
                            }
                        }
                        break;
                }
            }
        }
    }
}