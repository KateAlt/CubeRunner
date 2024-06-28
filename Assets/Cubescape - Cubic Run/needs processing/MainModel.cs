using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MainModel", menuName = "MainModel")]
public class MainModel : ScriptableObject
{
    // private Vector3 CharacterPos;
    // public Vector3 characterPos
    // {
    //     get { return CharacterPos; }
    //     set { 
    //             CharacterPos = value; 
    //             roundPos = (int)System.Math.Round(characterPos.z / 5.0f) * 5;
    //         }
    // }

    public bool canMove;

    // public int oldDataPos;
    // public int roundPos;
    
    [Space(50)] 
    public int countPlatforms;
    public GameObject boxPlatform;

    public int minCountPlatform;
    public int maxCountPlatform;

    public Material[] colorsMat; 

    public IEnumerator MoveBox(GameObject obj, Vector3 targetPos, float speed)
    {
        while (obj.transform.position != targetPos)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetPos, speed * Time.deltaTime);
            if (obj.transform.position == targetPos)
            {
                yield break;
            }
            yield return null;
        }
    }

    private void OnEnable()
    {
        canMove = false;
        // levelGame = 0;
    }
}
