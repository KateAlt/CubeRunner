using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Positions))]
public class LevelsDatatestDrawer : PropertyDrawer
{
    private const float ColumnCount = 2f;
    private const int GapSize = 5;
    private const float GapCount = ColumnCount - 1;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        var x = position.x;
        var y = position.y;
        var width = (position.width - GapCount * GapSize) / ColumnCount;
        var height = EditorGUIUtility.singleLineHeight;
        var offset = width + GapSize;
        
        EditorGUI.PropertyField(new Rect(x, y, width, height), property.FindPropertyRelative("position"), GUIContent.none);
        EditorGUI.PropertyField(new Rect(x + offset, y, width / 2, height), property.FindPropertyRelative("objKind"), GUIContent.none);
        EditorGUI.PropertyField(new Rect(x + 2 * offset - (width / 2), y, width / 2, height), property.FindPropertyRelative("objType"), GUIContent.none);
        // EditorGUI.PropertyField(new Rect(x + 3 * offset, y, width / 2f, height), property.FindPropertyRelative("key"), GUIContent.none);

        EditorGUI.EndProperty();
    }
}
  