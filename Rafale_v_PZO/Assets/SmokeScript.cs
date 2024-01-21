using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour
{   
    public GameObject smoke;
    public GameObject sound;

    

    // Start is called before the first frame update
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            smoke.SetActive(true);
            sound.SetActive(true);
        }
    }
}
