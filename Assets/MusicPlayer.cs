using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class MusicPlayer : MonoBehaviour
{
   [Header("Music Player Settings")]
   [SerializeField] private AudioSource audioSource;// Reference to the AudioSource component
    [SerializeField] private AudioClip mainMusicClip;// Music clip for the main theme
   [SerializeField] private Slider volumeSlider;// Slider to adjust the volume

    private void Start()
    {
        PlayMainTheme();
    }
    /// <summary>
    /// Plays the main theme music.
    /// </summary>
    public void PlayMainTheme()
    {
        if (audioSource.clip != mainMusicClip)
        {
            audioSource.clip = mainMusicClip;
            audioSource.Play();
        }
    }
    /// <summary>
    /// Adjust the volume of the music player.
    /// </summary>
    public void SetVolume()
    {
        audioSource.volume = volumeSlider.value;
    }

}
