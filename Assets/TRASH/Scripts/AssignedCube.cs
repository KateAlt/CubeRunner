using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignedCube : MonoBehaviour
{
    public GameObject objectToDelete;
    public MainData mainData;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(mainData.soundBreaking);
            objectToDelete.GetComponent<PlatfonmMechanics>().enabled = true;
            objectToDelete.transform.parent = null;
        }
    }
}
