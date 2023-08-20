using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public MainData MainData;
    public GameObject uiPauseMenu;
    
    public Image imageToUpdate; // Reference to the UI Image component
    public Sprite playSprite;    // The new sprite you want to assign
    public Sprite pauseSprite;    // The new sprite you want to assign

    public void PauseMenu()
    {
        MainData.canStart = false;
        uiPauseMenu.SetActive(true);
        ChangeSprite();
    }

    
    void ChangeSprite()
    {
        if(imageToUpdate.sprite == pauseSprite)
        {
            imageToUpdate.sprite = playSprite;
            uiPauseMenu.SetActive(false);
            MainData.canStart = true;

        }
        else
        {
            imageToUpdate.sprite = pauseSprite;
        }
    }
}
