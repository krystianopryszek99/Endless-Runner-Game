using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

// use this to store the scores, highscore

public class GameData : MonoBehaviour
{
    public static GameData instance;
    public static GameData singleton;
    public Text scoreText = null;
    private int score = 0;
    public Text highscoreText;
    int highscore = 0;
    [SerializeField] float scoreToGet = 0;

    void Start()
    {
        // reset the counter 
        scoreText.text = score.ToString();
        // highscore set to 0 as default 
        highscore = PlayerPrefs.GetInt("highscore", 0);
        // updating the highscore text
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        //nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void Awake()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("GameData");
        if(go.Length < 1)
        //if(go.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else 
        {
            DontDestroyOnLoad(this.gameObject); 
            singleton = this;
        }
    }

    public void UpdateScore(int s)
    {
        score += s;
        // update text on the screen here as well.
        if( scoreText != null)
        {
            // updating the text
            scoreText.text = score.ToString();
            // if highscore is smaller than score then
            if(highscore < score)
                // run the PlayerPrefs
                // this will only update the highscore if player beats the current highscore
                // stores the highscore using PlayerPrefs
                PlayerPrefs.SetInt("highscore", score);
        }
        // when the score is greater or equal to specified score
        // then load next scene from the build settings 
        if (score >= scoreToGet) 
        {   
            // if player gets to level 3, player wins
            if(SceneManager.GetActiveScene().buildIndex == 4)
            {
                Debug.Log("You Won!");
            }
            else
            {
                Time.timeScale = 0f;
                FindObjectOfType<GameController>().NextLevel();
            }
        }
    }

    public void DoubleScore(int s)
    {
        score += s;
    }

    // method to pause the game
    public void PauseGame()
    {
        // sets the time to 0, which means the whole game pauses 
        Time.timeScale = 0f;
    }

    // method to unpause the game
    public void UnPauseGame()
    {
        // sets the time to 1, which means the whole game resume
        Time.timeScale = 1f;
    }
}
