using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Script for player movement, lives, reset the player 
// at the start, check for lives left in player prefs
// set the life icons accordingly.

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] Sprite aliveIcon;
    [SerializeField] Sprite deadIcon;
    [SerializeField] Image[] lifeIcons;
    public static GameObject player;
    public static GameObject currentPlatform;
    bool canTurn = false;
    // deal with lives
    int livesLeft;
    public static bool isDead = false;
    MeshRenderer[] mr;
    // audio
    [SerializeField] private AudioClip livesPickUpSound;
    // animation
    private float animationDuration = 3.0f;
    private Animator anim;
    // Jump
    public float jumpForce = 6;
    private Rigidbody rb;
    private bool isGrounded;
    public bool gamePlaying { get; private set; }
    
    void Start()
    {
        mr = this.GetComponentsInChildren<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
        anim = GetComponentInChildren<Animator>();
        player = this.gameObject;
        CreateFromPool.RunPhantom();
        livesLeft = PlayerPrefs.GetInt("LivesLeft");    // string ref
        // set the life icons
        UpdateLifeIcons(livesLeft);
        isDead = false;
    }

    // check for user input
    void Update()
    {
        if(Time.time < animationDuration)
        {
            canTurn = false;
            return;
        }
        if (isDead == true) return;
        PlayerMovement();
    }
    
    // Reset player
    // stop animation, set player to alive so he can move,
    // reset the current level the player is in
    // and set the timescale to 1 so the game can play
    public void ResetPlayer()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        isDead = false;
        canTurn = false;
        // will require more code for storing game data like score
        // singleton that is set to DontDestroyOnLoad
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single); 
        Time.timeScale = 1;
    }

    // Player movement
    // move left on A, move right on D, jump on space
    private void PlayerMovement()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(-0.5f, 0, 0);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Translate(0.5f, 0, 0);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
           rb.velocity = new Vector3(0f, 6.0f, 0f);
           isGrounded = false;
        }
    }

    // On collision,
    // play die animation, set player to dead, take life away,
    // update life and the life icon 
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Death")
        {
            anim.SetTrigger("Die");
            // run death animations - trigger, bool
            isDead = true;
            livesLeft--;
            PlayerPrefs.SetInt("LivesLeft", livesLeft); // update this
            UpdateLifeIcons(livesLeft);
            
            // if lives is 0,
            // when player is in level 3, reset the player on death 
            // otherwise invoke the game over screen on death
            // and reset when player looses 1 life
            if(livesLeft == 0)
            {
                // if the player is in level 3
                if(SceneManager.GetActiveScene().buildIndex == 4)
                {
                    Invoke("ResetPlayer", 1.0f);
                }
                else
                {
                    Invoke("GameOverMenu", 2.0f); // game over
                }
            }
            else
            {
                Invoke("ResetPlayer", 1.0f);    // to start of the level
            }
        }
        else
        {
            currentPlatform = other.gameObject;
        }

        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
            
    }
    
    // Update life icon
    // when player looses life, dead icon appears 
    // and when player picks up 'extra heart',
    // alive icon appears
    public void UpdateLifeIcons(int lives)
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (i >= lives)
            {
                lifeIcons[i].sprite = deadIcon;
            }
            else if (i <= lives)
            {
                lifeIcons[i].sprite = aliveIcon;
            }

        }
    }

    // When player life is 0,
    // game and aniators stops,
    // Invoke the game over screen
    private void GameOverMenu()
    {
        gamePlaying = false;
        gameObject.GetComponent<Animator>().enabled = false;
        Invoke("ShowGameOverScreen", 0.1f); 
    }

    // Displays game over screen
    private void ShowGameOverScreen()
    {
        FindObjectOfType<GameController>().ShowGameOver();
    }

    // On pickup
    // play audio clip, update life if current player life is less than 3
    // and update the life icon
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Heart")
        {   
            // play audio when player picks up a life
            AudioSource.PlayClipAtPoint(livesPickUpSound, Camera.main.transform.position);
            if(livesLeft == 3)
            {
                // don't do anything
                Debug.Log("Your health is max, no health was added!");
            }
            else
            {
                // add 1 life to player score
                livesLeft++;
                PlayerPrefs.SetInt("LivesLeft", livesLeft);
                UpdateLifeIcons(livesLeft);
                foreach( MeshRenderer m in mr)
                    m.enabled = false;
            }
        }
    
        if (other is SphereCollider)
            canTurn = true;
        else if(other is BoxCollider)
            CreateFromPool.RunPhantom();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other is SphereCollider)
            canTurn = false;
       
    }
}
