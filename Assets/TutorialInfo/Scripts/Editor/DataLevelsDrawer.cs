// using UnityEngine;
// using UnityEditor;

// [CustomPropertyDrawer(typeof(NamedAudioClip))]
// public class NamedAudioClipDrawer : PropertyDrawer
// {
//     private const int ColumnCount = 2;
//     private const int GapSize = 4;

//     public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//     {
//         EditorGUI.BeginProperty(position, label, property);

//         float columnWidth = (position.width - (ColumnCount - 1) * GapSize) / ColumnCount;
//         float yPosition = position.y;

//         SerializedProperty keyProperty = property.FindPropertyRelative("key");

//         Rect keyRect = new Rect(position.x, yPosition, columnWidth, EditorGUIUtility.singleLineHeight);
//         EditorGUI.PropertyField(keyRect, keyProperty, GUIContent.none);

//         // Відображення мітки поля
//         EditorGUI.LabelField(position, label);
//         // Поле зі значенням переліку
//         position.x += EditorGUIUtility.labelWidth;
//         position.width -= EditorGUIUtility.labelWidth;
        
//         property.enumValueIndex = EditorGUI.Popup(position, property.enumValueIndex, property.enumDisplayNames);
        

//         EditorGUI.EndProperty();
//     }
// }
