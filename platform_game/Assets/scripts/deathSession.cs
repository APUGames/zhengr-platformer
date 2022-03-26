using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class deathSession : MonoBehaviour
{
    [SerializeField] float delayTime = 1.5f;
    public bool winCon = false;

    private void Awake(){
        StartCoroutine(LoadNextLevel());
    }


    IEnumerator LoadNextLevel(){

        yield return new WaitForSecondsRealtime(delayTime);

        FindObjectOfType<gameSession>().processPlayerDeath();
    }

    void Update()
    {
        
    }
}
