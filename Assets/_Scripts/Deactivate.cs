using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to deactivate a platform when the player exits the collider

public class Deactivate : MonoBehaviour
{
    bool forDeactivation = false;

    private void OnTriggerExit(Collider other)
    {
        if((other.gameObject.tag == "Player") &&
           (forDeactivation == false))
        { 
            Invoke("SetPlatformInactive", 1.0f);
            forDeactivation = true;
        }
    }
    private void SetPlatformInactive()
    {
        print("Set inactive" + this.gameObject.name);
        this.gameObject.SetActive(false);
        forDeactivation = false;
    }
}
