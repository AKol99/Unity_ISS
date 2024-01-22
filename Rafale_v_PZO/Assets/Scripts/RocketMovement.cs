using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField]float movementSpeed = 40f;
    [SerializeField]float rotationSpeed = 40f;

    public float destroyTime = 10f;
    public bool isMoving = false;
    public GameObject explosionPrefab;
    public AudioClip explosionSound;
    public float explosionVolume = 1.8f;
    public bool countdownStarted = false;
    public Vector3 startingPosition = new Vector3(0f, 13f, 0f);
    public Quaternion startingRotation = Quaternion.Euler(-20f, 90f, 0f);
    public GameObject smoke;
    public GameObject sound;
    public bool collision = false;


    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Space))
                {
                    isMoving = true;
                }

                if (isMoving)
                {
                    Thrust();
                    Rotation();
                    smoke.SetActive(true);
                    sound.SetActive(true);
                }

                if (isMoving && !countdownStarted) {
                    countdownStarted = true;
                    Invoke("MissileExplosion", destroyTime);
                }
        
    }

    void Thrust() {
        Vector3 thrustDirection = transform.forward;

    // Apply thrust to the rocket using transform.Translate
    transform.Translate(thrustDirection * Time.deltaTime * movementSpeed, Space.World);
    }

    void Rotation() {
        Vector3 currentRotation = transform.rotation.eulerAngles;

        
        float yRotation = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        currentRotation.y += yRotation;
        float xRotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        currentRotation.x += xRotation;

        // Apply the new rotation to the object
        transform.rotation = Quaternion.Euler(currentRotation);
    }

    void MissileExplosion()
    {   
        if (!collision) {
            isMoving = false;
            gameObject.SetActive(false);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            PlayExplosionSound();
            Invoke("SetNewMissile", 1.5f);
        }
        
        
    }

    public void SetNewMissile() {
        SetPositionRelativeToParent(startingPosition);
        transform.rotation = startingRotation;
        gameObject.SetActive(true);
        isMoving = false;
        countdownStarted = false;
        smoke.SetActive(false);
        sound.SetActive(false);
    }

    public void MissileCancelInvoke() {
        CancelInvoke("MissileExplosion");
    }

     private void PlayExplosionSound()
    {
         if (explosionSound != null)
        {
            // Create an empty GameObject to act as an audio source
            GameObject audioSourceObject = new GameObject("ExplosionAudioSource");
            AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();

            // Set the audio clip and volume
            audioSource.clip = explosionSound;
            audioSource.volume = explosionVolume;

            // Play the sound
            audioSource.Play();

            // Destroy the audio source object after the sound finishes
            Destroy(audioSourceObject, explosionSound.length + 2f);
        }

    }

    void SetPositionRelativeToParent(Vector3 localPosition)
    {
        // Ensure the object has a parent before adjusting its position
        if (transform.parent != null)
        {
            // Transform the local position to world space using TransformPoint
            Vector3 worldPosition = transform.parent.TransformPoint(localPosition);

            // Set the position in world space
            transform.position = worldPosition;
        }
        else
        {
            Debug.LogWarning("The object has no parent. Unable to set position relative to parent.");
        }
    }
}

    
