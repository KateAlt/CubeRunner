using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DDData", menuName = "KKevelsData", order = 1)]
public class MainData : ScriptableObject
{   
    [SerializeField] 
    public int countCubes;

    [SerializeField]
    public float speedOfMove = 5;

    [SerializeField]
    public bool canStart;

    [SerializeField]
    public int level;
}
