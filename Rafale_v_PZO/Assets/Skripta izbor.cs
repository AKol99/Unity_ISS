using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skriptaizbor : MonoBehaviour
{
    public GameObject objekt1;
    public GameObject objekt2;

    public GameObject kamera1;
    public GameObject kamera2;

    private int izbor;
    private Rigidbody rb1;
    private Rigidbody rb2;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            izbor = 1;
            kamera1.SetActive(true);
            kamera2.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            izbor = 2;
            kamera1.SetActive(false);
            kamera2.SetActive(true);
        }


        if(izbor==1)
        {
             rb1 = objekt1.GetComponent<Rigidbody>();

             float h = Input.GetAxis("Horizontal") * 5;
             float v = Input.GetAxis("Vertical") * 5;

             Vector3 vel = rb1.velocity;
             vel.x = h;
             vel.z = v;
             rb1.velocity = vel;
        }

        if(izbor==2)
        {
             rb2 = objekt2.GetComponent<Rigidbody>();

             float h = Input.GetAxis("Horizontal") * 5;
             float v = Input.GetAxis("Vertical") * 531;

             Vector3 vel = rb2.velocity;
             vel.x = h;
             vel.z = v;
             rb2.velocity = vel;
        }
    }
}
