using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public MainData MainData;
    
    public float sensitivity = 2f;
    public float clampX = 5f;

    void Update()
    {
        if(Input.GetMouseButton(0) && MainData.canStart)
        {
            float mouseX = Input.GetAxis("Mouse X");

            Vector3 moveDirection = new Vector3(mouseX * sensitivity, 0f, 0f);
            transform.Translate(moveDirection);

            Vector3 currentPosition = transform.position;
            currentPosition.x = Mathf.Clamp(currentPosition.x, -clampX, clampX);
            transform.position = currentPosition;
        }
    }
}