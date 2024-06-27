using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public MainData mainData;

    public GameObject cubePrefab;
    public Transform parentObject;

    public GameObject uiFall;
    public GameObject uiWin;

    // private AudioSource audioSource;
    public ParticleSystem coinParticleSystem;

    void Start()
    {
        // audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Cube"))
        {
            // audioSource.PlayOneShot(mainData.soundCubeAssigned);
            Destroy(collision.gameObject);

            GameObject enemy = Instantiate(cubePrefab, new Vector3(0f, mainData.countCubes + 1f, 0f), Quaternion.identity);
                    enemy.transform.SetParent (parentObject.transform, false);
        }

        if (collision.CompareTag("Finish"))
        {
            mainData.canStart = false;
            uiWin.SetActive(true);

            
        }

        // if (collision.CompareTag("Coin"))
        // {
        //     mainData.countCoins++; 
        //     audioSource.PlayOneShot(mainData.soundCoin);
        //     coinParticleSystem.Play();
        //     Destroy(collision.gameObject); 
        // }
    }

    void Update()
    {
        mainData.countCubes = gameObject.transform.childCount - 1;
        if(mainData.countCubes <= 0)
        {
            mainData.canStart = false;
            uiFall.SetActive(true);
        }
    }

    void OnDisable()
    {
        mainData.speedOfMove = 7f;
        mainData.countCubes = 0;
        mainData.canStart = false;
    }
}
