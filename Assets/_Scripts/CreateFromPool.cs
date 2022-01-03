using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to spawn platfroms 
public class CreateFromPool : MonoBehaviour
{
    [SerializeField] int NumberOfPlatforms = 5;
    public static GameObject phantom;
    public static GameObject lastPlatform;

    private void Awake()
    {
        phantom = new GameObject("phantom");

    }
    public static void RunPhantom()
    {
        GameObject p = Pool.singleton.GetRandom();
        Vector3 adjustment;

        if (p == null) return; // pool empty
        // is there a previous platform
        if(lastPlatform != null)
        {
            phantom.transform.position = lastPlatform.transform.position +
                                PlayerBehaviour.player.transform.forward * 30.0f;
        }

        lastPlatform = p;
        p.SetActive(true);
        p.transform.position = phantom.transform.position;
        p.transform.rotation = phantom.transform.rotation;

        if( p.tag == "Platform1" && ObstacleController.addObstacle == true)
        {
            GameObject f = Instantiate(Pool.singleton.fencePrefab,
                                        p.transform.position,
                                        p.transform.rotation);
            f.transform.forward = p.transform.forward;
            f.transform.SetParent(p.transform);
        }
    }
}
