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
    public class SpawnMeneger : MonoBehaviour
    {
        public GameObject character;
        private int trackLength;
        private LevelsData levData;
        
        public static int[] positionWallTest;
        public static int[] positionCoinTest;

        public static Material[] matPlatform;
        public static Material matWall;

        private int countSection = 10;

        public static event Action<GameObject> CreateFirstPlatforms;
        public static event Action<float> SpawnTracker;
        public static event Action<int> CreateFinishPlatforms;
        public static event Action<int> CreateFinishEffects;

        public static event Action<bool> CanStartCharacter;
        // public static event Action<bool> IsPausedGame;
        
        private void Awake()
        {
            LevelsData.isPaused = false;
            LevelsData.isRnning = false;

            // -- download resources
            levData = Resources.Load<LevelsData>("LevelsData");
            positionWallTest = levData.lev[levData.levelGame].GetWallsData();
            positionCoinTest = levData.lev[levData.levelGame].GetCoinsData();

            matPlatform = levData.lev[levData.levelGame].platformMat;
            matWall = levData.lev[levData.levelGame].wallMat;
        }

        void Start()
        {
            CreateFirstPlatforms?.Invoke(levData.lev[levData.levelGame].GetFirstPlatform());

            trackLength = levData.lev[levData.levelGame].GetPlatformData();
            StartTimer();
        }

        private void FixedUpdate()
        {
            if(character.transform.position.z >= (float)trackLength + 2f)
            {
                LevelsData.isPaused = true;
                // CreateFinishEffects?.Invoke(countSection);
            }
        }

        private void StartTimer()
        {
            StartCoroutine(TimerTracer());
        }
        
        public IEnumerator TimerTracer()
        {
            while(countSection <= trackLength)
            {
                yield return new WaitForSeconds(0.5555555556f);

                if (LevelsData.isPaused)
                {
                    yield break;
                }

                SpawnTracker?.Invoke((float)countSection);

                countSection = countSection + 5;
                if(countSection == 60)
                {
                    CanStartCharacter?.Invoke(true);
                    LevelsData.isRnning = true;
                }

                if(countSection >= trackLength)
                {
                    CreateFinishPlatforms?.Invoke(countSection);
                    yield return new WaitForSeconds(0.5555555556f);

                    CreateFinishEffects?.Invoke(countSection);
                    CreateFinishPlatforms?.Invoke(countSection + 5);
                    yield break;
                }
            }
                                                                // DISTANCE float distance = Vector3.Distance(startPoint, endPoint);
                                                                // SPEED float speed = mySpeed;
                                                                // TIME float time = distance / speed;
                                                                // 5 / 9 = 0.5555555556f
        }

        private void OnEnable()
        {
            UIGameAreaView.OffPauseSet += StartTimer;
        }

        private void OnDisable()
        {
            UIGameAreaView.OffPauseSet -= StartTimer;
        }
    }
}