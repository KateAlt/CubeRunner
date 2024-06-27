using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehavior : MonoBehaviour
{
    public GameObject blockPlatforms;
    public float speed;

    private Vector2 startPos;
    private Vector2 direction;

    public int[] positions;
    public int selectionLev;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    // Handle movement logic if needed
                    break;

                case TouchPhase.Ended:
                    direction = touch.position - startPos;

                    if (direction.x > 50f) // Swipe to the right
                    {
                        selectionLev = (selectionLev == 0) ? 0 : selectionLev - 1;
                        StartCoroutine(Move(positions[selectionLev]));
                        Debug.Log(selectionLev);
                    }
                    else if (direction.x < -50f) // Swipe to the left
                    {
                        selectionLev = selectionLev + 1;
                        StartCoroutine(Move(positions[selectionLev]));
                        Debug.Log(selectionLev);
                    }
                    break;
            }
        }
    }

    IEnumerator Move(float pos)
    {
        Vector3 targetPos = new Vector3(pos, 0f, 0f);
        Debug.Log("targetPos: " + targetPos);

        while (blockPlatforms.transform.position != targetPos)
        {
            blockPlatforms.transform.position = Vector3.MoveTowards(blockPlatforms.transform.position, targetPos, speed * Time.deltaTime);
            if(blockPlatforms.transform.position == targetPos)
            {
                yield break;
            }
            yield return null; // or yield return new WaitForSeconds(someSmallValue);
        }
    }
}
