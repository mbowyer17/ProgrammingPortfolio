using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
public class EndSceneScript : MonoBehaviour
{
    [SerializeField]Text previousWinText;
    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        var player = FindObjectOfType<PlayerInventory>().gameObject;
        var gm = FindObjectOfType<TheGameManager>().gameObject;
        var ui = FindObjectOfType<UiManager>().gameObject;

        //previousWinText.text = gm.GetComponent<ScoreManager>().GetTotalScore().ToString();


        Destroy(player);
        Destroy(gm, 0.5f);
        Destroy(ui);
    }
    // Update is called once per frame
    void Update()
    {
        LoadTotalData();
    }
    void LoadTotalData()
    {
        var saveFile = Application.persistentDataPath + "/gamedata.json";
        string fileContents = File.ReadAllText(saveFile);
        var gameData = JsonUtility.FromJson<GameData>(fileContents);
        previousWinText.text = "Final Score:" + gameData.totalScore.ToString();
        print(gameData.totalScore);
        

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
