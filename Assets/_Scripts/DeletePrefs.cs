using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manages the deletion of PlayerPrefs,

public class DeletePrefs : MonoBehaviour
{
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
