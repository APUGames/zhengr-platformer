using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicScript : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource music;

    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        music = GetComponent<AudioSource>();
        
    }

    private void PlayMusic(){
        if (music.isPlaying) return;
        music.Play();
    }

    public void StopMusic() {
        music.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
