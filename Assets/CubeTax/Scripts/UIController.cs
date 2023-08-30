using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public MainData mainData;
    public GameObject uiPauseMenu;
    
    public Image imageToUpdate;
    public Sprite playSprite;
    public Sprite pauseSprite;

    public void PauseMenu()
    {
        mainData.canStart = false;
        uiPauseMenu.SetActive(true);
        ChangeSprite();
    }

    
    void ChangeSprite()
    {
        if(imageToUpdate.sprite == pauseSprite)
        {
            imageToUpdate.sprite = playSprite;
            uiPauseMenu.SetActive(false);
            mainData.canStart = true;

        }
        else
        {
            imageToUpdate.sprite = pauseSprite;
        }
    }
}
