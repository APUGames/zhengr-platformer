using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitScript1 : MonoBehaviour
{
    [SerializeField] float delayTime = 2.0f;
    [SerializeField] float sloMoFactor = 0.2f;
    public bool winCon = false;
    Rigidbody2D enemyCharacter;
    
    void Start()
    {
        winCon = false;
        enemyCharacter = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(enemyCharacter.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            winCon = true;
            if(winCon){
                StartCoroutine(LoadNextLevel());
            }
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
