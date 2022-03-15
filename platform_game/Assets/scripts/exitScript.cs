using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitScript : MonoBehaviour
{
    [SerializeField] float delayTime = 2.0f;
    [SerializeField] float sloMoFactor = 0.2f;
    public bool winCon = false;

    private void OnTriggerEnter2D(Collider2D collision) {
            if(winCon){
                StartCoroutine(LoadNextLevel());
            }
    }

    IEnumerator LoadNextLevel(){

        Time.timeScale = sloMoFactor;


        yield return new WaitForSecondsRealtime(delayTime);

        Time.timeScale = 1.0f;
        
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
    }


}
