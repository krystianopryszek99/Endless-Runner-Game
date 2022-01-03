using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for coin pickup 
// when collect a coin, player gets score
public class CoinPickup : MonoBehaviour
{
    // different level, different score per pickup
    [SerializeField] private int pointsForCoin = 10; 
    [SerializeField] private AudioClip coinPickUpSound;
    MeshRenderer[] mr;
    private int value;
    private bool doublePickedUp;

    private void Start()
    {
        gameObject.tag = "Player";
        doublePickedUp = false;
        mr = this.GetComponentsInChildren<MeshRenderer>();
    }
    
    // On pickup, 
    // play the clip, update the score and disable the mesh renderers
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            AudioSource.PlayClipAtPoint(coinPickUpSound, Camera.main.transform.position);
            GameData.singleton.UpdateScore(pointsForCoin);
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