using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script which scrolls selected objects 
// scrolls the platforms, obstacles, collectables
public class Scroller : MonoBehaviour
{
    [SerializeField] private float speed = -0.1f; 
    private void FixedUpdate()
    {
        if (PlayerBehaviour.isDead == true) return;

        // the speed of the objects scrolling/moving
        this.transform.position +=
                        PlayerBehaviour.player.transform.forward * speed;

    }
}
