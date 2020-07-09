using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    float defaultVolume = 0.8f;

    private void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume(defaultVolume);
        StartCoroutine(StartDelayedMusic());
    }

    IEnumerator StartDelayedMusic()
    {
        yield return new WaitForSeconds(3f);
        audioSource.Play();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

}
