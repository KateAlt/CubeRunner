using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ControlerUI : MonoBehaviour
{
    public UIDocument doc;
    private VisualElement root;

    private void Awake()
    {
        root = doc.rootVisualElement;

        var myButton = root.Q<Button>("myButton");
            myButton.clickable.clicked += () => { 
                SceneManager.LoadScene("MainMenu");
            };
    }
}
