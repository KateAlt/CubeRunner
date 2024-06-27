// Author: Kateryna Fedenko
// Creation Date: Apr 2024
// License: Creative Commons Attribution-NonCommercial (CC BY-NC)
// Project Link: https://github.com/KateAlt/CubeTax

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace CubicRun.MainGame
{
    public class UIGameAreaView : MonoBehaviour
    {
        public UIDocument doc;
        private VisualElement root;

        VisualElement pausePanel;
        VisualElement topBarInf;
        private VisualElement wayPointerVie;

        public static event Action OffPauseSet;
        
        void OnEnable()
        {
            GameAreaController.OnScoreCountChanged += LabelScorePlus;
            GameAreaController.UpdateWayLine += SetWayLine;
            
            CharacterController.IsFinish += OnPausePanel;

            GameAreaController.SetStarRating += SetCountStar;
        }

        void OnDisable()
        {
            GameAreaController.OnScoreCountChanged -= LabelScorePlus;
            GameAreaController.UpdateWayLine -= SetWayLine;
            
            CharacterController.IsFinish -= OnPausePanel;

            GameAreaController.SetStarRating -= SetCountStar;
        }

        private void Awake() 
        {
            root = doc.rootVisualElement;

            pausePanel = root.Q<VisualElement>("PausePanel");
            topBarInf = root.Q<VisualElement>("jj");

            var pauseBtn = root.Q<Button>("PauseBtn");
            pauseBtn.clickable.clicked += () => { 
                if(LevelsData.isPaused == false)
                {
                    LevelsData.isPaused = true;
                    OnPausePanel();
                }
            };

            var playBtn = root.Q<Button>("PlayBtn");
            playBtn.clickable.clicked += () => { 
                if(LevelsData.isPaused != false)
                {
                    LevelsData.isPaused = false;
                    OffPausePanel();
                }
            };

            var menuBtn = root.Q<Button>("MenuBtn");
            menuBtn.clickable.clicked += () => { 
                SceneManager.LoadScene("MainMenu");
            };

            LabelScorePlus(0);
            
            wayPointerVie = root.Q<VisualElement>("WayPointerElm");
        }
        
        public void OnPausePanel()
        {
            pausePanel.style.display = DisplayStyle.Flex;
            topBarInf.style.display = DisplayStyle.None;

            SetDataWavyBall(GameAreaController.starRating);
        }

        public void OffPausePanel()
        {
            pausePanel.style.display = DisplayStyle.None;
            topBarInf.style.display = DisplayStyle.Flex;

            OffPauseSet.Invoke();
        }

        public void LabelScorePlus(int value)
        {
            Label scorePlusLab = root.Q<Label>("ScorePlusLab");
            // scorePlusLab.text = value.ToString();
            scorePlusLab.text = string.Concat(GameAreaController.plusRating, "/", GameAreaController.plusRemainingLev);
        }

        public void SetWayLine(float value)
        {
            wayPointerVie.style.width = new Length(value, LengthUnit.Percent);
        }
        
        public void SetCountStar(int value)
        {
            VisualElement[] starIcons = new VisualElement[3];
            starIcons[0] = root.Q<VisualElement>("star_1");
            starIcons[1] = root.Q<VisualElement>("star_2");
            starIcons[2] = root.Q<VisualElement>("star_3");

            for (int i = 0; i < value; i++)
            {
                starIcons[i].style.unityBackgroundImageTintColor = new Color(0.2627451f, 0.1333333f, 0.145098f, 1f);
            }
        }
        
        private void SetDataWavyBall(int value)
        {
            Label levLab = root.Q<Label>("LevelLabel");
            levLab.text = string.Concat("LEV. ", GameAreaController.lev + 1);

            VisualElement[] starIcons = new VisualElement[3];
            starIcons[0] = root.Q<VisualElement>("wavyStar_1");
            starIcons[1] = root.Q<VisualElement>("wavyStar_2");
            starIcons[2] = root.Q<VisualElement>("wavyStar_3");

            for (int i = 0; i < value; i++)
            {
                starIcons[i].style.unityBackgroundImageTintColor = new Color(0.2627451f, 0.1333333f, 0.145098f, 1f);
            }

            Label plusCollectedLabel = root.Q<Label>("PlusCollectedLabel");
            plusCollectedLabel.text = string.Concat(GameAreaController.plusRating, "/", GameAreaController.plusRemainingLev);
        }
    }
}