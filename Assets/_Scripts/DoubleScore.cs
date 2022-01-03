using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for double score
public class DoubleScore : MonoBehaviour
{
    private int value;
    [SerializeField] private AudioClip coinPickUpSound;
    [SerializeField] int doubleScoreValue = 5;
    private bool doublePickedUp;
    private void Start()
    {
        doublePickedUp = false;
    }

    // Enable the double score for 10 seconds
    private IEnumerator StopDouble()
    {
        yield return new WaitForSeconds(10);
        GameData.singleton.DoubleScore(10);
    }
    
    // When player collect 'double' score,
    // player gets score depending on the level 
    // play audio clip 
    // update the score
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            AudioSource.PlayClipAtPoint(coinPickUpSound, Camera.main.transform.position);
            doublePickedUp = true;
            StartCoroutine("StopDouble");
            GameData.singleton.DoubleScore(doubleScoreValue);
        }
    }
}
