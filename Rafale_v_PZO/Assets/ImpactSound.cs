using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{
    public float destroyPlaneOnSpeed = 700f;
    public AudioSource impactSound;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude * 3.6f > destroyPlaneOnSpeed)
        {
            impactSound.Play();
        }
    }

}
