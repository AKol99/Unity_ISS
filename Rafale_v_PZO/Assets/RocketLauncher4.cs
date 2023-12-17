using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher4 : MonoBehaviour
{
    public Transform rocketSpawnPoint;
    public GameObject rocketPrefab;
    public float rocketSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            var rocket = Instantiate(rocketPrefab, rocketSpawnPoint.position, rocketSpawnPoint.rotation);
            rocket.GetComponent<Rigidbody>().velocity = rocketSpawnPoint.forward * rocketSpeed;
        }
    }
}
