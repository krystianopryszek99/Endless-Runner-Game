using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for adding health to the player 
// when player collects the heart, he will get 1 life 
public class AddHealth : MonoBehaviour
{
    int livesLeft;
    MeshRenderer[] mr;
    
    void Start()
    {
        // string reference
        livesLeft = PlayerPrefs.GetInt("LivesLeft"); 
        FindObjectOfType<PlayerBehaviour>().UpdateLifeIcons(livesLeft);
        mr = this.GetComponentsInChildren<MeshRenderer>();
    }

    // On collision, when player pickups heart,
    // player will receive 1 life, which also updates the life icon
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Heart")
        {
            livesLeft++;
            PlayerPrefs.SetInt("LivesLeft", livesLeft);
            FindObjectOfType<PlayerBehaviour>().UpdateLifeIcons(livesLeft);
            //disable the mesh renderers
            foreach( MeshRenderer m in mr)
                m.enabled = false;
        }

    }

    private void OnEnable()
    {
        if(mr != null)
        {
            foreach(MeshRenderer m in mr)
                m.enabled = true;
        }
    }
}
