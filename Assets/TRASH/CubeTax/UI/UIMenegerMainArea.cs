using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIMenegerMainArea : MonoBehaviour
{
    public UIDocument document;
    public float speedRotation;
    private VisualElement billet;

    private void Start()
    {
        var root = document.rootVisualElement;

        billet = root.Q<VisualElement>("Billet");
        // billet.style.width = new Length(50, LengthUnit.Percent);
    }

    void Update()
    {
        // Отримати поточне обертання елемента
        Quaternion currentRotation = billet.transform.rotation;

        // Змінити тільки кут обертання навколо осі Z
        float newZRotation = currentRotation.eulerAngles.z + Time.deltaTime * speedRotation;

        // Задати нове обертання
        billet.transform.rotation = Quaternion.Euler(0, 0, newZRotation);
    }
}
