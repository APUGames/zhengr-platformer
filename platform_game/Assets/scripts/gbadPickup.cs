using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gbadPickup : MonoBehaviour
{
    [SerializeField] AudioClip collectSound;
    //bool winCon : set to false

    private void OnTriggerEnter2D(Collider2D collision){
        //on collision, set winCon to true
        AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);
        //in exit script, if (winCon = true), then StartCoroutine(LoadNextLevel());...
    }

}
