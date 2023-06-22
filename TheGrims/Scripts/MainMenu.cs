using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TheGameManager manager;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject main;

    private void Start()
    {
        Scene sceneName = SceneManager.GetActiveScene();
        Time.timeScale = 1;
        if (sceneName.name == "MainMenu")
        {
            credits.SetActive(false);
        }
           
    }

    public void LoadCredits()
    {
        credits.SetActive(true);
        main.SetActive(false);
    }

    public void LoadMenu()
    {
        credits.SetActive(false);
        main.SetActive(true);
    }
    public void ExitScene()
    {
        Application.Quit();
    }

    public void PickScene(string name)
    {
       
        SceneManager.LoadScene(name);
            
    }

    

    

}
