using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameSession : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] int playerLives = 3;
    [SerializeField] int playerScore = 0;
    [SerializeField] float delayTime = 0.0f;
    //[SerializeField] Text lives;
    [SerializeField] Text score;


    BoxCollider2D playerBodyCollider;


    private void Awake(){
        int numGameSessions = FindObjectsOfType<gameSession>().Length;

        if(numGameSessions > 1){
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }

    }

    public void ProcessPlayerScore(int points) {
        playerScore += points;
        score.text = playerScore.ToString();
    }

    //new changes here down

    public void processPlayerDeath(){
            StartCoroutine(ResetGameSession());
    }

   /* IEnumerator ResetGameSession(){

        yield return new WaitForSecondsRealtime(delayTime);

        yield return new WaitForSecondsRealtime(delayTime);

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Destroy(gameObject);

    }*/

    IEnumerator ResetGameSession(){

        yield return new WaitForSecondsRealtime(delayTime);

        string sceneName = PlayerPrefs.GetString("lastLoadedScene");
        SceneManager.LoadScene(sceneName);

        Destroy(gameObject);

    }

    /*IEnumerator ResetGameSession(){
        
        if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy"))) {
            SceneManager.LoadScene(22);
        Destroy(gameObject);
        }
        else if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("BadPickup"))) {
            SceneManager.LoadScene(23);
        Destroy(gameObject);
        }
        else if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("PTSD"))) {
            SceneManager.LoadScene(24);
        Destroy(gameObject);
        }
        else if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Hazards"))) {
            SceneManager.LoadScene(25);
        Destroy(gameObject);
        }

        yield return new WaitForSecondsRealtime(delayTime);

    }*/


    void Start()
    {
        //lives.text = playerLives.ToString();
        score.text = playerScore.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
