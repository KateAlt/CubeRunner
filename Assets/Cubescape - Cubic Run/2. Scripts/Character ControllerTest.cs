using System;
using UnityEngine;

namespace CubicRun.MainGame
{
    public class CharacterControllerTest : MonoBehaviour
    {
        public ParticleSystem effectPlusing;
            public float step;


            public float speedMove;
            public float boardMove;
            public float sensibilityMove;

            Vector2 startPos  = Vector2.zero;

            private Vector3 targetPos;
            private bool isMoving = false;
            public float moveSpeed = 5f;


            private AudioSource source;

            public static event Action<int> PlusPoint;
            public static event Action IsFinish;
        
            void Start()
            {
                source = GetComponent<AudioSource>();
            }

            void Update()
            {
                if(true)
                {
                    Move();
                }
            }

            public void Move()
            {
                transform.Translate(Vector3.forward * speedMove * Time.deltaTime);

                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Moved)
                    {
                        float touchDeltaX = touch.deltaPosition.x;

                        Vector3 moveDirection = new Vector3(touchDeltaX * sensibilityMove, 0f, 0f);
                        transform.Translate(moveDirection);

                        Vector3 currentPosition = transform.position;
                        currentPosition.x = Mathf.Clamp(currentPosition.x, -boardMove, boardMove);
                        transform.position = currentPosition;
                    }
                }

                // if (Input.touchCount == 1)
                // {
                //     Touch touch = Input.GetTouch(0);

                //     switch (touch.phase)
                //     {
                //         case TouchPhase.Began:
                //             startPos = touch.position;
                //             Debug.Log("TouchPhase.Began" + transform.position);
                //             break;

                //         case TouchPhase.Ended:
                //             Vector3 direction = touch.position - startPos;

                //             if (direction.x > 40f)           // Swipe to the right
                //             {
                //                 targetPos = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
                //                 isMoving = true;
                //             }
                //             else if (direction.x < -40f)     // Swipe to the left
                //             {
                //                 targetPos = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
                //                 isMoving = true;
                //             }
                //             break;
                //     }
                // }

                // if (isMoving)
                // {
                //     transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

                //     if (Vector3.Distance(transform.position, targetPos) < 0.01f)
                //     {
                //         transform.position = targetPos;
                //         isMoving = false;
                //     }
                // }
            }

            void OnTriggerEnter(Collider other)
            {
                if(other.CompareTag("Wall"))
                {
                    Destroy(other.gameObject);
                }

                if(other.CompareTag("Plus"))
                {
                    // FX
                    effectPlusing.Play();
                    source.Play();
                    
                    PlusPoint?.Invoke(1);
                    Destroy(other.gameObject);
                }

                if(other.CompareTag("Finish"))
                {
                    FinishController.newEffect.Play();
                    IsFinish?.Invoke();
                }
            }
    }
}