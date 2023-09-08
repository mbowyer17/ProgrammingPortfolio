using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioSource menuMusic;
    [SerializeField] Text previousText;

    private void Awake()
    {
        LoadPreviousData();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MuteMusic()
    {
        //
        menuMusic.mute = !menuMusic.mute;
    }

    void LoadPreviousData()
    {
        var saveFile = Application.persistentDataPath + "/gamedata.json";
        string fileContents = File.ReadAllText(saveFile);
        var gameData = JsonUtility.FromJson<GameData>(fileContents);
        previousText.text = "Previous Score: " + gameData.totalScore.ToString();
        


    }
}
