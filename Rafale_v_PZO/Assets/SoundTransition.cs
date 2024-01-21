using UnityEngine;

public class SoundTransition : MonoBehaviour
{
    public AudioClip soundClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private bool isSpaceClicked = false;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && !isSpaceClicked)
        {   
            isSpaceClicked = true;
            
            PlaySound();
        }

    }

    void PlaySound()
    {
        if (soundClip != null)
        {
            audioSource.clip = soundClip;
            audioSource.Play();
        }
    }
}
