using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MainData", menuName = "KKevelsData", order = 1)]
public class MainData : ScriptableObject
{   
    public int level;
    public int countCubes;
    public float speedOfMove = 5;
    public bool canStart;

    [Header("Level Settings")]
    public int minCountWall;
    public int maxCountWall;

    public int minSpace;
    public int maxSpace;
}
