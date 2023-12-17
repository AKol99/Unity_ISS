using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher1 : MonoBehaviour
{
    public Transform rocketSpawnPoint;
    public GameObject rocketPrefab;
    public float rocketSpeed = 10;

    private bool _rocketReloaded;

    // Start is called before the first frame update
    void Start()
    {
        _rocketReloaded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_rocketReloaded)
        {
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                var rocket = Instantiate(rocketPrefab, rocketSpawnPoint.position, rocketSpawnPoint.rotation);
                rocket.GetComponent<Rigidbody>().velocity = rocketSpawnPoint.forward * rocketSpeed;
            }
        }

        
    }
}
