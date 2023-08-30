using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorSchems", order = 1)]
public class ColorSchemes : ScriptableObject
{
    [Header("Green")]
    public Color[] greenColor;

    [Header("Orange")]
    public Color[] orangeColor;

    [Header("Blue")]
    public Color[] blueColor;
}
