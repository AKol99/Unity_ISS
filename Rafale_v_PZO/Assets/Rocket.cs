using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float life = 10;
    public AudioSource impactSound;
    public GameObject explosion;
    public float maxDistanceSound = 5000;

    private Rigidbody rocketRigidbody;

    private void Awake()
    {
        rocketRigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {

        impactSound.Play();
        float delay = 1f;
        if (rocketRigidbody != null)
        {
            rocketRigidbody.velocity = Vector3.zero;
            rocketRigidbody.angularVelocity = Vector3.zero;
            rocketRigidbody.isKinematic = true;
        }
        Invoke("DestroyRocket", delay);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    private void DestroyRocket()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject avion = GameObject.FindGameObjectWithTag("Avion");
        Physics.IgnoreCollision(avion.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
