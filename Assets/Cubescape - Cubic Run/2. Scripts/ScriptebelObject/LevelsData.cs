using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CubicRun.MainGame
{
    [CreateAssetMenu(fileName = "LevelsData", menuName = "Levels Data")]
    public class LevelsData : ScriptableObject
    {        
        public LevData[] lev;

        public static bool isPaused = false; // є призупинено = так true
        public static bool isRnning = false; // є рухливий    = ні  false

        [SerializeField] [Range (0, 10)]
        private int LevelGame;
        public int levelGame
        {
            get { return LevelGame; }

            set { if(value > lev.Length)
                    LevelGame = lev.Length;
                    else if (value < 0)
                    LevelGame = 0;
                    else
                    LevelGame = value;
                }
        }

        // data of top bar 
        private static int CoinPlus;
        public static global::System.Int32 coinPlus{ get => CoinPlus; set => CoinPlus = value; }

        private static int CoinStar;
        public static global::System.Int32 coinStar{ get => CoinStar; set => CoinStar = value; }

        public bool GetIsLevelLocked() // 
        {
            return lev[levelGame].isLockLev;
        }

        public int GetStarData()  //
        {
            return lev[levelGame].starCount;
        }

        public int GetCoinCollected()
        {
            return lev[levelGame].plusCollected;
        }

        public int GetCoinRemaining()
        {
            return lev[levelGame].plusRemaining;
        }

        public int GetStarRemaining()
        {
            return lev[levelGame].starRemaining;
        }
    }
}