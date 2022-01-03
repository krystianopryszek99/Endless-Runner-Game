using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script is used to launch pause menu, options menu and disable the game data panel when displaying these menus
public class LevelSceneController : MonoBehaviour
{
    public GameObject gameDataPanel, pauseMenu, optionsMenuPanel;

    // pauses the game
    public void Pause_OnClick()
    {
        FindObjectOfType<GameData>().PauseGame();
        // load the pause menu.
        SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
    }

    // resumes the game 
    public void Resume_OnClick()
    {
        gameDataPanel.SetActive(true);
        pauseMenu.SetActive(false);
        FindObjectOfType<GameData>().UnPauseGame();
    }

    // Displays the options menu
    public void Options_OnClick()
    {
        pauseMenu.SetActive(false);
        optionsMenuPanel.SetActive(true);
    }

    // When clicked, takes the player back to pause menu
    public void Back_OnClick()
    {
        optionsMenuPanel.SetActive(false);
        pauseMenu.SetActive(true);
    }

    // Exits the game
    public void Exit_OnClick()
    {
        Debug.Log("Quit the application!");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); 
    }
}
