using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "SampleScene";
    public string levelToLoadCredit = "Credits";
    public void Play()
    {
        FindObjectOfType<AudioManager>().PlayAudio("Click");
        Invoke("LoadScene", 0.5f);
    }

    public void Exit()
    {
        Debug.Log("Quitting");
        Application.Quit();
        FindObjectOfType<AudioManager>().PlayAudio("Click2");
    }

    public void Credits()
    {
        Invoke("LoadCredits", 0.5f);
        FindObjectOfType<AudioManager>().PlayAudio("Click");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(levelToLoadCredit);
    }
}
