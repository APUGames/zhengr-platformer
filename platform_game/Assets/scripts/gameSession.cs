using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameSession : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int playerLives = 3;
    [SerializeField] int playerScore = 0;
    [SerializeField] float delayTime = 2.5f;
    [SerializeField] Text lives;
    [SerializeField] Text score;

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

    public void processPlayerDeath(){
        if (playerLives > 1) {
             StartCoroutine(SubtractLife());
        }
        else {
            StartCoroutine(ResetGameSession());
        }
    }

    IEnumerator SubtractLife(){
        playerLives--;

        yield return new WaitForSecondsRealtime(delayTime);

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        lives.text = playerLives.ToString();
    }

    IEnumerator ResetGameSession(){

        yield return new WaitForSecondsRealtime(delayTime);

        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    void Start()
    {
        lives.text = playerLives.ToString();
        score.text = playerScore.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
