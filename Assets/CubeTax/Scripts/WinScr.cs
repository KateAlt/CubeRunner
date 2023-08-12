using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScr : MonoBehaviour
{
    public GameObject UIElemWin;

    void OnCollisionEnter(Collision collision) {
        MainDate.canStart = false;
        UIElemWin.SetActive(true);
    }
}
