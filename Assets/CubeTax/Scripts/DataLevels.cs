using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "LevelsData", menuName = "ScriptableObjects/LevelsData", order = 17)]
public class DataLevels : ScriptableObject
{

    [SerializeField, Min(1)]
    public int numberOfPlatforms;

    public PositionOfCube[] casesCube;
    public PositionOfWall[] casesWall;
}


[System.Serializable]
public struct PositionOfCube
{
    public string name;
    public Vector3 position;
    public ParameterCube parameterCube;
}

[System.Serializable]
public struct PositionOfWall
{
    public string name;
    public Vector3 position;
    public ParameterWall parameterWall;
}


[System.Serializable]
public enum ParameterWall { wallType1, wallType2, wallType3}

[System.Serializable]
public enum ParameterCube { cubeType1 }