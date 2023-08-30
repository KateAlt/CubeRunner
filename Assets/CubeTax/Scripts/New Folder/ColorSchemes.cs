using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorSchems", order = 1)]
public class ColorSchemes : ScriptableObject
{
    [Header("Green")]
    public Color lightGreenColor;
    public Color skyGreenColor;
    public Color platformGreenColor;
    public Color wallGreenColor;

    [Header("Orange")]
    public Color lightOrangeColor;
    public Color skyOrangeColor;
    public Color platformOrangeColor;
    public Color wallOrangeColor;

    [Header("Blue")]
    public Color lightBlueColor;
    public Color skyBlueColor;
    public Color platformBlueColor;
    public Color wallBlueColor;
}
