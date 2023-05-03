using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; // Singleton instance

    public List<AudioClip> audioClips = new List<AudioClip>(); // List of audio clips to play
    public AudioSource audioSource; // Audio source component

    void Awake()
    {
        // Ensure only one instance of the sound manager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Play a random audio clip from the list
    public void PlayRandomClip()
    {
        if (audioClips.Count == 0) return;

        int index = Random.Range(0, audioClips.Count);
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    // Play a specific audio clip by index in the list
    public void PlayClipByIndex(int index)
    {
        if (index < 0 || index >= audioClips.Count) return;

        audioSource.clip = audioClips[index];
        audioSource.Play();
    }
}