using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] float score, scoreMultipler;
    [SerializeField] float scoreScene1, scoreScene2, scoreScene3, scoreScene4, totalScore;
    [SerializeField] float maxScore = 10000f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.fixedDeltaTime * scoreMultipler;
        GetSceneScore();
        if (score >= maxScore)
        {
            score = maxScore;
        }
        /* if (Input.GetKeyDown(KeyCode.V))
         {
             score += 40;
         } */
    }

    public float GetScore()
    {
        return (int)score;
    }

    public float GetSceneScore1()
    {
        return (int)scoreScene1;
    }
    public float GetSceneScore2()
    {
        return (int)scoreScene2;
    }
    public float GetSceneScore3()
    {
        return (int)scoreScene3;
    }
    public float GetTotalScore()
    {
        return (int)totalScore ;
    }

    public void GetSceneScore()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                scoreScene1 = 0;
                break;
            case 2:
                scoreScene2 = score;
                break;
            case 3:
                scoreScene3 = score;
                break;
            case 4:
                scoreScene4 = score;
                break;
            case 5:

                totalScore = scoreScene2 + scoreScene3 + scoreScene4;
                SaveFile();
                break;
            default:
                print("SceneNotFound");
                break;
        }
        
    }
    
    public void SetScore(float value)
    {
        
            score = value;
               
    }
    public void SaveFile()
    {
        var gameData = new GameData() { totalScore = (int)GetTotalScore() };
        string jsonString = JsonUtility.ToJson(gameData);
        var saveFile = Application.persistentDataPath + "/gamedata.json";
        File.WriteAllText(saveFile, jsonString);
        print("Saved");
    }
    
    
   
}
