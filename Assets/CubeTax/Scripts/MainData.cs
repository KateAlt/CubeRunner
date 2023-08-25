using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DDData", menuName = "KKevelsData", order = 1)]

public class MainData : ScriptableObject
{   
    public int countCubes;
    public float speedOfMove = 5;
    public bool canStart;
}
