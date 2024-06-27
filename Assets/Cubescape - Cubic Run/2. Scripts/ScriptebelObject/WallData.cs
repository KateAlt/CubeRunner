using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubicRun.MainGame
{
    [CreateAssetMenu(fileName = "wallData", menuName = "wallData")]
    public class WallData : ScriptableObject
    {
        [SerializeField] public CoordinateBoxWalls[] positionOfSpawnWall;
    }

    [System.Serializable]
    public class CoordinateBoxWalls
    {
        [SerializeField] public Vector2[] wallConstruction;
    }
}