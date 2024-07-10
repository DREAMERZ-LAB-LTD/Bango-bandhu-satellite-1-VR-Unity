using UnityEngine;

public class AudioController : MonoBehaviour
{
    private bool isMuted = false;
    private AudioSource audioSource;

    public GameObject _soundIcon; 
    public GameObject _muteIcon; 
    void Start()
    {
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleMute()
    {
        // Toggle the mute state
        isMuted = !isMuted;
        // Set the mute state of the AudioSource
        audioSource.mute = isMuted;
        if (isMuted)
        {
            _soundIcon.SetActive(false);
            _muteIcon.SetActive(true);
            audioSource.Pause();
        }
        else
        {
            _soundIcon.SetActive(true);
            _muteIcon.SetActive(false);
            audioSource.Play();
        }
    }
}
