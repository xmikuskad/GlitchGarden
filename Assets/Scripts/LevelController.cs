using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    int numberOfAliveAttackers = 0;
    bool levelTimerFInished = false;

    float defaultVolume = 0.8f;

    public void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAliveAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAliveAttackers--;
        if(levelTimerFInished && numberOfAliveAttackers<=0)
        {
            StartCoroutine(HandleWinCondition());
        }
    }
    public void LevelTimerFinished()
    {
        levelTimerFInished = true;
        StopSpawners();
    }
    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner attackerSpawner in spawnerArray)
        {
            attackerSpawner.StopSpawning();
        }
    }

    IEnumerator HandleWinCondition()
    {
        GetComponent<AudioSource>().volume = PlayerPrefsController.GetMasterVolume(defaultVolume);
        GetComponent<AudioSource>().Play();
        winLabel.SetActive(true);
        yield return new WaitForSeconds(3f);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

}
