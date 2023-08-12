using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float sensitivity = 2f; // Чутливість миші
    public float clampX = 5f; // Максимальний обмеження зміщення по осі X

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            // Отримуємо значення зміщення миші по горизонталі
            float mouseX = Input.GetAxis("Mouse X");

            // Застосовуємо зміщення вліво-вправо до позиції куба
            Vector3 moveDirection = new Vector3(mouseX * sensitivity, 0f, 0f);
            transform.Translate(moveDirection);

            // Обмежуємо зміщення по осі X
            Vector3 currentPosition = transform.position;
            currentPosition.x = Mathf.Clamp(currentPosition.x, -clampX, clampX);
            transform.position = currentPosition;
        }
    }
}