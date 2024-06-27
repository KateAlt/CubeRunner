using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubicRun.MainGame
{
    public class TestCharMove : MonoBehaviour
    {
        public float speedMove;
        Vector2 startPos  = Vector2.zero;
        Vector2 direction = Vector2.zero;

        public float sens;

        void Update()
        {
            Move();
        }

        public void Move()
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        startPos = touch.position;
                    break;

                    case TouchPhase.Ended:
                        direction = touch.position - startPos;

                        if (direction.x > 0)           // Swipe to the right +
                        {
                            StartCoroutine(MoveBox(gameObject, new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z), sens));
                        }
                        if (direction.x < 0)          // Swipe to the left -
                        {
                            StartCoroutine(MoveBox(gameObject, new Vector3(transform.position.x + -1.0f, transform.position.y, transform.position.z), sens));
                        }
                    break;                    
                }
            }
            transform.Translate(Vector3.forward * speedMove * Time.deltaTime);
        }

        public IEnumerator MoveBox(GameObject obj, Vector3 targetPos, float speed)
        {
            while (obj.transform.position != targetPos)
            {
                if (true)
                {
                    obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetPos, speed * Time.deltaTime);
                }
                if (obj.transform.position == targetPos)
                {
                    yield break;
                }
                yield return null;
            }
        }
    }
}