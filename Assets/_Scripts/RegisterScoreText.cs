using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// tell the game data class that this is the score text field

public class RegisterScoreText : MonoBehaviour
{
    void Start()
    {
        GameData.singleton.scoreText = this.GetComponent<Text>();
    }

}
