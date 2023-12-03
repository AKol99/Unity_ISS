using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Plane : MonoBehaviour
{
    [Header("Plane Stats")]
    [Tooltip("How much the throttle ramps up or down.")]
    public float throttleIncrement = 0.2f;
    [Tooltip("Maximum engine thrust when at 100% throttle.")]
    public float maxThrust = 52000f;
    [Tooltip("How responsive the plane is when rolling, pitching and yawing.")]
    public float responsiveness = 200f;

    private float throttle;
    private float roll;
    private float pitch;
    private float yaw;


    private float responseModifier {
        get {
            return (rb.mass / 10f) * responsiveness;
        }
    }

    private Rigidbody rb;
    [SerializeField] private TextMeshProUGUI hud;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void HandleInputs()
    {
        // Set rotational values from our axis inputs
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");
        
        // Handle throttle value, being sure to clamp it between 0-100
        if (Input.GetKey(KeyCode.I)) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.J)) throttle -= throttleIncrement;
        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }

    private void Update()
    {
        HandleInputs();
        UpdateHUD();
    }

    private void FixedUpdate()
    {
        // Apply forces to our plane.
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * responseModifier);
        rb.AddTorque(transform.right * pitch * responseModifier);
        rb.AddTorque(transform.forward * roll * responseModifier);
        rb.AddForce(-transform.up * 9.81f * 9979f);
        
        // if (rb.velocity.y < 0 && transform.position.y > 200)
        // {
        //     // Calculate the rotation angle based on the fall speed
        //     float angle = Mathf.Lerp(0, 90, Mathf.Abs(rb.velocity.y) / 10.0f);
        //
        //     // Apply rotation gradually
        //     Quaternion targetRotation = Quaternion.Euler(angle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        //     transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 0.1f);
        // }
    }
    
    private void UpdateHUD()
    {
        hud.text = "Throttle: " + throttle.ToString("F1") + "%\n";
        hud.text += "Airspeed: " + (rb.velocity.magnitude * 3.6f).ToString("F1") + "km/h\n";
        hud.text += "Altitude: " + transform.position.y.ToString("F1") + "m";
    }
}
