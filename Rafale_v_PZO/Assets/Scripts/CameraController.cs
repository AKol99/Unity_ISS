using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
    [Tooltip("An array of transforms representing camera positions.")]
    [SerializeField] Transform[] povs;
    [Tooltip("The speed at which the camera follows the plane.")]
    [SerializeField] private float speed;

    private int index = 0;
    private Vector3 target;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1)) index = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) index = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) index = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha4)) index = 3;

        target = povs[index].position;
    }

    private void FixedUpdate()
    {
        // Move camera to the desired position/orientation. Must be in FixedUpdate to avoid camera jitters.
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        transform.forward = povs[index].forward;
    }
    
}
