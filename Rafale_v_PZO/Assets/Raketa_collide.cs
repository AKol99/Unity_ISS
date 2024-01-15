using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raketa_collide : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Avion"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
