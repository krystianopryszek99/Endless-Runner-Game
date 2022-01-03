using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // starts the game with 3 lifes
    int maxLives = 3;
    public bool gamePlaying { get; private set; }
    public int nextSceneLoad;

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // onClick event handlers

    // Game Over
    // Takes the player to main menu
    public void MainMenu_OnClick()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    // Option Menu
    // returns the player back to the main menu
    public void Back_OnClick()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    // exits the game
    public void QuitGame()
    {
        Application.Quit();
    }

    // Winning Menu
    // Launches next level, eg. if player is in level 1,
    // launches level 2
    public void NextLevel_OnClick()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Launches the level selection menu
    public void LevelSelection_OnClick()
    {
        SceneManager.LoadScene("LevelSelection", LoadSceneMode.Single);
    }

    // Launches level 1 from the level selection menu
    public void Level1_OnClick()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("LivesLeft", maxLives);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    // Launches level 2 from the level selection menu
    public void Level2_OnClick()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("LivesLeft", maxLives);
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    // Launches level 3 from the level selection menu
    public void Level3_OnClick()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("LivesLeft", maxLives);
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);
    }

    // Resets PlayerPrefs on click in the options menu
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
