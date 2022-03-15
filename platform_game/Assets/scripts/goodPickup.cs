using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goodPickup : MonoBehaviour
{

    [SerializeField] AudioClip collectSound;
    //bool winCon : set to false
    [SerializeField] int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D collision){

        FindObjectOfType<gameSession>().ProcessPlayerScore(coinValue);
        FindObjectOfType<exitScript>().winCon = true;
        //on collision, set winCon to true
        AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);
        Destroy(gameObject);
        //in exit script, if (winCon = true), then StartCoroutine(LoadNextLevel());...
    }

}
