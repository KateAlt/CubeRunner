using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelsDatatest", order = 17)]
public class LevelsDatatest : ScriptableObject
{
    [SerializeField]
    public Positions[] level01;

    public int platform;
}

[System.Serializable]
public class Positions
{
    public KindObj objKind;
    public int objType;

    public Vector3 position; 
    // public string key;
}

public enum KindObj
{
    none,
    cube,
    wall,
    coin
}