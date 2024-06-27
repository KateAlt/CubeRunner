// Script Name: MenuController.cs
// Author: Kateryna Fedenko
// Creation Date: Apr 2024
// License: Creative Commons Attribution-NonCommercial (CC BY-NC)
// Project Link: https://github.com/KateAlt/CubeTax

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CubicRun.MainGame
{
    public class UIMenuView : MonoBehaviour
    {
        public UIDocument doc;
        private VisualElement root;

        private VisualElement starRatingElm;

        private VisualElement plusesBloc;
        private VisualElement starsBloc;

        private void Awake() 
        {
            root = doc.rootVisualElement;

            starRatingElm = root.Q<VisualElement>("STARS");
            plusesBloc = root.Q<VisualElement>("PlusDataElement");
            starsBloc = root.Q<VisualElement>("StarDataElement");
        }

        void OnEnable()
        {
            MenuModel.SetTopBar += SetUpTopBarData;

            MenuModel.SetMainTitle += SetUpMainTitle;

            MenuModel.SetStarRating += SetUpStarRating;
            MenuModel.SetDataRating += SetUpDataRating;

            MenuModel.SetUnblockData += SetUpUnblockData;

            MenuModel.SetHint += HintText;
        }

        void OnDisable()
        {
            MenuModel.SetTopBar -= SetUpTopBarData;

            MenuModel.SetMainTitle -= SetUpMainTitle;

            MenuModel.SetStarRating -= SetUpStarRating;
            MenuModel.SetDataRating -= SetUpDataRating;

            MenuModel.SetUnblockData -= SetUpUnblockData;

            MenuModel.SetHint -= HintText;
        }

        /// <summary>
        /// The method outputs data about the values that the player has. Its are displayed at the top of the screen.
        /// </summary>
        private void SetUpTopBarData(int star, int plus) 
        {
            Label coinStarLabel = root.Q<Label>("CoinStarLabel");
            Label coinPlusLabel = root.Q<Label>("CoinPlusLabel");

            coinStarLabel.text = star.ToString();
            coinPlusLabel.text = plus.ToString();
        }

        /// <summary>
        /// The method displays the number of the level or the inscription that the level is blocked. It is displayed in a wavy ball in the middle of the screen.
        /// </summary>
        private void SetUpMainTitle(string title)
        {
            Label levelLabel = root.Q<Label>("LevelLabel");
            levelLabel.text = title;
        }

        private void SetUpUnblockData(string valid, string claim)
        {
            starRatingElm.style.display = DisplayStyle.None;
            plusesBloc.style.display = DisplayStyle.None;

            starsBloc.style.display = DisplayStyle.Flex;
            
            Label starLabel = root.Q<Label>("StarLabel");
            starLabel.text = string.Concat(valid, "/", claim);
        }

        private void SetUpDataRating(string valid, string claim)
        {
            Label claimClowerLabel = root.Q<Label>("ClaimCloverLabel");
            claimClowerLabel.text = string.Concat(valid, "/", claim);
        }

        private void SetUpStarRating(int value)
        {
            starRatingElm.style.display = DisplayStyle.Flex;
            plusesBloc.style.display = DisplayStyle.Flex;

            starsBloc.style.display = DisplayStyle.None;

            VisualElement[] starIcons = new VisualElement[3];
            starIcons[0] = root.Q<VisualElement>("1_StarIcon");
            starIcons[1] = root.Q<VisualElement>("2_StarIcon");
            starIcons[2] = root.Q<VisualElement>("3_StarIcon");

            Color activeColor = new Color(0.2627451f, 0.1333333f, 0.145098f, 1f);  // white
            Color inactiveColor = new Color(0.7333333f, 0.7647059f, 0.8196079f, 1f);

            for (int i = 0; i < starIcons.Length; i++)
            {
                if (i < value)
                {
                    starIcons[i].style.unityBackgroundImageTintColor = activeColor;
                }
                else
                {
                    starIcons[i].style.unityBackgroundImageTintColor = inactiveColor;
                }
            }
        }

        public void HintText(string text)
        {
            Label hintLabel = root.Q<Label>("HintLabel");

            hintLabel.text = text;
        }
    }
}