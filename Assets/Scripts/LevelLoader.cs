using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float waitingTime = 3f;

    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex==0)
        {
            StartCoroutine(WaitAndLoad());
        }
    }
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(waitingTime);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        if (currentSceneIndex < 4)
            SceneManager.LoadScene(currentSceneIndex + 1);
        else
            LoadStartScreen();
    }

    public void LoadYouLose()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void LoadStartScreen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }
}
