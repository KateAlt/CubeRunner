using System;
using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CubicRun.MainGame
{
    [CreateAssetMenu]
    public class LevData : ScriptableObject 
    {
        [Space(20)]
        [SerializeField] public bool isLockLev;
        [SerializeField] private GameObject firstPlatform;

        [SerializeField] [Range (0, 3)] public int starCount;

        [Space(20)] // in unblock lev
        [SerializeField] public int plusCollected;
        [SerializeField] public int plusRemaining;

        [Space(20)] // in block lev
        [SerializeField] public int starRemaining;

        [SerializeField] public Material wallMat;
        [SerializeField] public Material[] platformMat;


        [Space(20)]
        [SerializeField] private Level[] lev;

        private void OnEnable()
        {
            {
                plusRemaining = 0;

                for(int i = 0; i < lev.Length; i++)
                {
                    if(lev[i].typeObj == TypeObj.coin)
                        plusRemaining++;
                }
            }
        }

        public int GetPlatformData()  
        {
            return lev.Length;
        }

        public int[] GetWallsData()  
        {
            int[] result = new int[lev.Length];
            for(int i = 0; i < lev.Length; i++)
            {
                if(lev[i].typeObj == TypeObj.wall)
                    result[i] = (int)lev[i].typeWall;
            }

            return result;
        }
        
        public int[] GetCoinsData()  
        {
            int[] result = new int[lev.Length];
            plusRemaining = 0;

            for(int i = 0; i < lev.Length; i++)
            {
                if(lev[i].typeObj == TypeObj.coin)
                {
                    result[i] = (int)lev[i].positionX;
                    plusRemaining++;
                }
                else
                {
                    result[i] = 999;
                }
            }

            return result;
        }

        public int[] GetBoxesData()  
        {
            int[] result = new int[lev.Length];

            for(int i = 0; i < lev.Length; i++)
            {
                if(lev[i].typeObj == TypeObj.box)
                    result[i] = (int)lev[i].positionX;
            }

            return result;
        }

        public GameObject GetFirstPlatform()
        {
            return firstPlatform;
        }
    }

    [Serializable]
    public class Level
    {
        [SerializeField] public TypeObj typeObj;

        [SerializeField] public TypeCoin positionX;
        [SerializeField] private int positionY;
        [SerializeField] private int positionZ;

        [SerializeField] public TypeWall typeWall;
    }

    public enum TypeCoin
    {
        a = -2, b = -1, c = 0, d = 1, e = 2
    }

    public enum TypeObj
    {
        space, wall, coin, box
    }

    public enum TypeWall
    {
        type0, type1, type2, type3, type4, type5, type6, type7, type8, type9, type10
    }
        
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(Level))]
    public class LevelPropertyDrawer : PropertyDrawer
    {
        private const float space = 5;
        private static readonly string[] displayNames = { "-2", "-1", "0", "1", "2"};

        public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
        {
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var firstLineRect = new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight);
            DrawMainProperties(firstLineRect, property, label);

            EditorGUI.indentLevel = indent;
        }

        private void DrawMainProperties(Rect rect, SerializedProperty property, GUIContent label)
        {
            float partWidth = (rect.width - 2 * space) / 10;

            rect.width = partWidth * 1;
            string textNum = label.text.Substring(7);
            EditorGUI.LabelField(rect, string.Concat(textNum, " pos"));
            
            rect.x += rect.width + space;
            rect.width = partWidth * 3;
            EditorGUI.PropertyField(rect, property.FindPropertyRelative("typeObj"), GUIContent.none);


            SerializedProperty typeObjProp = property.FindPropertyRelative("typeObj");
            TypeObj typeObjValue = (TypeObj)typeObjProp.enumValueIndex;

            if (typeObjValue == TypeObj.wall)
            {
                // space
                rect.x += rect.width + space;
                rect.width = partWidth * 0.25f;
                EditorGUI.LabelField(rect, "  ");

                rect.x += rect.width + space;
                rect.width = partWidth * 1.5f;
                EditorGUI.PropertyField(rect, property.FindPropertyRelative("typeWall"), GUIContent.none);
            }

            if (typeObjValue == TypeObj.coin || typeObjValue == TypeObj.box)  // 0.75 + 3 = 3.75
            {
                // X
                rect.x += rect.width + space;
                rect.width = partWidth * 0.25f;
                EditorGUI.LabelField(rect, "X ");

                rect.x += rect.width + space;
                rect.width = partWidth * 1.5f;
                // EditorGUI.PropertyField(rect, property.FindPropertyRelative("typeCoin"), GUIContent.none);

                //! - - - -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  - 
                // Отримайте властивість typeCoin
                SerializedProperty typeCoinProperty = property.FindPropertyRelative("positionX");
                
                // Перетворіть enum на індекс для Popup
                int selectedIndex = typeCoinProperty.enumValueIndex;

                // Намалюйте Popup з власними текстовими значеннями
                selectedIndex = EditorGUI.Popup(rect, selectedIndex, displayNames);

                // Встановіть нове значення enum на основі вибраного індексу
                typeCoinProperty.enumValueIndex = selectedIndex;
                //! - - -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  - 

                // Y
                rect.x += rect.width + space;
                rect.width = partWidth * 0.25f;
                EditorGUI.LabelField(rect, "Y ");

                // Automatically set the value of positionZ to 4 and make it non-editable
                rect.x += rect.width + space;
                rect.width = partWidth * 1.5f;
                GUI.enabled = false;
                var positionYProperty = property.FindPropertyRelative("positionY");
                positionYProperty.intValue = 1;
                EditorGUI.PropertyField(rect, positionYProperty, GUIContent.none);
                GUI.enabled = true;

                // Z
                rect.x += rect.width + space;
                rect.width = partWidth * 0.25f;
                EditorGUI.LabelField(rect, "Z ");

                // Automatically set the value of positionZ to 4 and make it non-editable
                rect.x += rect.width + space;
                rect.width = partWidth * 1.5f;
                GUI.enabled = false;
                var positionZProperty = property.FindPropertyRelative("positionZ");
                positionZProperty.intValue = int.Parse(textNum);
                EditorGUI.PropertyField(rect, positionZProperty, GUIContent.none);
                GUI.enabled = true;
            }
        }
    }
#endif
}
