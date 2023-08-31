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

    private Coroutine restartCoroutine;

    
    public void PauseAndPlayButton()
    {
        if (imageToUpdate.sprite == pauseSprite)
        {
            imageToUpdate.sprite = playSprite;
            uiPauseMenu.SetActive(true);
            mainData.canStart = false;
            if (restartCoroutine != null)
            {
                StopCoroutine(restartCoroutine);
            }
        }
        else
        {
            mainData.canStart = true;
            uiPauseMenu.SetActive(false);
            imageToUpdate.sprite = pauseSprite;
            restartCoroutine = StartCoroutine(ReStartData());
        }
    }


    public void StartCountSpeed()
    {
        if (restartCoroutine != null)
        {
            StopCoroutine(restartCoroutine);
        }
        restartCoroutine = StartCoroutine(ReStartData());
    }


    public IEnumerator ReStartData()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            mainData.speedOfMove += 0.1f;
        }
    }
}
