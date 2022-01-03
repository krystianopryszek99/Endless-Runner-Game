using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Camera Behaviour - Script for the camera animation
public class CameraBehaviour : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffSet;
    private Vector3 moveVector;
    private float transition = 0.0f;
    private float animationDuration = 2.0f;
    private Vector3 animationOffSet = new Vector3(0,5,5);
   
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
        startOffSet = transform.position - lookAt.position;
    }

    void Update()
    {
        moveVector = lookAt.position + startOffSet;
        // X
        moveVector.x = 0;

        // condition, if transition is greater than 1,
        // does normal movement 
        // otherwise means we are still in animation
        if(transition > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            // Animation at the start
            transform.position = Vector3.Lerp(moveVector + animationOffSet, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt (lookAt.position + Vector3.up);
        }
        
    }
}
