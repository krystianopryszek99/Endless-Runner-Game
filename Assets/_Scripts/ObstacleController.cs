using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] float SecondsBetweenSpawn = 1.5f;

    public static bool addObstacle = false;

    private float elapsedTime = 0.0f;

    void Update()
    {
        if(PlayerBehaviour.isDead == true) return;

        elapsedTime += Time.deltaTime;
        if(elapsedTime > SecondsBetweenSpawn)
        {
            elapsedTime = 0;
            addObstacle = true;
        }
    }
}
