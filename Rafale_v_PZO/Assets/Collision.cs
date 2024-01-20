using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject explosionPrefab;
    public AudioClip explosionSound;
    public float explosionVolume = 1.5f;
    
    public RocketMovement rocketMovementScript;

    void Start() {
        rocketMovementScript = GetComponent<RocketMovement>();
    }

    void OnTriggerEnter(Collider other)
    {   

        rocketMovementScript.collision = true;

        if (other.gameObject.tag == "enemy")
        {
            // Deactivate the current GameObject
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Play the explosion sound
            PlayExplosionSound();

        }

        if (other.gameObject.tag == "terrain")
        {   
            
            // Deactivate the current GameObject
            rocketMovementScript.MissileCancelInvoke();
            gameObject.SetActive(false);
            rocketMovementScript.isMoving = false;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Play the explosion sound
            PlayExplosionSound();
            Invoke("SetNewMissile", 1.5f);

        }

        
    }

    public void SetNewMissile() {
        rocketMovementScript.SetNewMissile();
        rocketMovementScript.collision = false;
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
            Destroy(audioSourceObject, explosionSound.length);
        }
    }
}
