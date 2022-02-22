using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goodPickup : MonoBehaviour
{

    [SerializeField] AudioClip collectSound;

    private void OnTriggerEnter2D(Collider2D collision){
        AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);
        Destroy(gameObject);

    }

}
