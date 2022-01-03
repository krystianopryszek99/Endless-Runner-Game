using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script for level selection

public class LevelSelections : MonoBehaviour
{
    public Button[] LevelButtons;

    // level 1 is enabled at the start, 
    // level 2 and 3 are disabled
    // when player completes level 1, level 2 will be enabled
    // and same with level 3
    void Start()
    {
        // specified the build index of level 1 which is 2
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < LevelButtons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                LevelButtons[i].interactable = false;
            }
        }
    }
}
