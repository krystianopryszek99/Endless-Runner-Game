using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script is used to create a timer for the game, 
// display game over menu
// display the time played in the game over menu 
// When game starts the timer starts 
public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameDataPanel, gameOverPanel, pauseMenu, winningPanel;
    public Text timeCounter;
    private float startTime, elapsedTime;
    TimeSpan timePlaying;
    public bool gamePlaying { get; private set; }
    public int nextSceneLoad;

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        gamePlaying = false;
        BeginGame();
    }

    private void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time;
    }

    void Update()
    {
        elapsedTime = Time.time - startTime;
        timePlaying = TimeSpan.FromSeconds(elapsedTime);

        string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
        timeCounter.text = timePlayingStr;
    }

    // game over menu
    // displays the time played
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        gameDataPanel.SetActive(false);
        string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
        gameOverPanel.transform.Find("FinalTimeText").GetComponent<Text>().text = timePlayingStr;
    }

    // pauses the game 
    // disables the game data panel with the life, score etc
    public void PauseMenus()
    {
        FindObjectOfType<GameData>().PauseGame();
        gameDataPanel.SetActive(false);
        pauseMenu.SetActive(true);
    }

    // Shows the win menu
    // displays the time to complete the run
    public void NextLevel()
    {
        gameDataPanel.SetActive(false);
        winningPanel.SetActive(true);
        PlayerPrefs.SetInt("levelAt", nextSceneLoad); 
        string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
        winningPanel.transform.Find("FinalWinningTimeText").GetComponent<Text>().text = timePlayingStr;
    }
}
