using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawrerPlatforms : MonoBehaviour
{
    public GameObject box;
    float posZ = 3.0f;

    private void Start()
    {
        CreateStartSection();
        InstantiatePlatforms();
    }

    public void CreateStartSection()
    {
        for (int y = 0; y < 5; y++)
        {
            Instantiate(box, new Vector3(-2.0f, 0.0f, posZ), Quaternion.identity);
            Instantiate(box, new Vector3(-1.0f, 0.0f, posZ), Quaternion.identity);
            Instantiate(box, new Vector3( 0.0f, 0.0f, posZ), Quaternion.identity);
            Instantiate(box, new Vector3( 1.0f, 0.0f, posZ), Quaternion.identity);
            Instantiate(box, new Vector3( 2.0f, 0.0f, posZ), Quaternion.identity);

            posZ += 1.0f;
        }
    }

    public void InstantiatePlatforms()
    {
        GameObject boxBlock = Instantiate(box, new Vector3( 0.0f, 10.0f, posZ - 10.0f), Quaternion.identity);

        MoveBlockTwo(boxBlock, new Vector3( 0.0f, 0.0f, posZ - 2.0f), 10f);
    }

    

    public void MoveBlockTwo(GameObject blockPlatforms, Vector3 targetPos, float speedPatform)
    {
        Debug.Log(blockPlatforms.transform.position + " " + targetPos);
        StartCoroutine(MoveCoroutine2(blockPlatforms, targetPos, speedPatform));
    }

    public IEnumerator MoveCoroutine2(GameObject block, Vector3 targetPos, float speedPatform)
    {
        while (block.transform.position != targetPos)
        {
            block.transform.position = Vector3.MoveTowards(block.transform.position, targetPos, speedPatform * Time.deltaTime);
            if (block.transform.position == targetPos)
            {
                yield break;
            }
            yield return null;
        }
    }
}
