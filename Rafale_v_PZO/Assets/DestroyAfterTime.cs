using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    // Time to wait before destroying the object (in seconds)
    public float destroyTime = 10f;

    // Variable to track whether the countdown has started
    private bool countdownStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        // Do not start the countdown automatically in the Start method
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the space key is pressed and the countdown hasn't started
        if (Input.GetKeyDown(KeyCode.Space) && !countdownStarted)
        {
            // Start the countdown
            countdownStarted = true;
            Invoke("DestroyObject", destroyTime);
        }
    }

    // Method to destroy the game object
    void DestroyObject()
    {
        // Destroy the game object
        Destroy(gameObject);
    }

   
}
