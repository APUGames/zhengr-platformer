using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class deathSession : MonoBehaviour
{
    [SerializeField] float delayTime = 2.0f;
    public bool winCon = false;

    private void Awake(){
        StartCoroutine(LoadNextLevel());
    }


    IEnumerator LoadNextLevel(){

        yield return new WaitForSecondsRealtime(delayTime);

        FindObjectOfType<gameSession>().processPlayerDeath();

        //var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndex+1);
    }

    void Update()
    {
        
    }
}
