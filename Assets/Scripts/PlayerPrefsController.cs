﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const float MIN_DIFFICULTY = 1f;
    const float MAX_DIFFICULTY = 3f;


    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            Debug.Log("Master volume changed to " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("BAD VOLUME VALUE");
        }
    }

    public static float GetMasterVolume(float defaultValue)
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY,defaultValue);
    }

    public static void SetDifficulty(float difficulty)
    {
        if(difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("BAD DIFFICULTY VALUE");
        }
    }

    public static int GetDifficulty(float defaultValue)
    {
        return (int)PlayerPrefs.GetFloat(DIFFICULTY_KEY,defaultValue);
    }

}
