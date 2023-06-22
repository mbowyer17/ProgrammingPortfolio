using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TheGameManager : MonoBehaviour
{
    [SerializeField] Text ammoText, scoreText;
    [SerializeField] PlayerInventory inventory;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] Image keyImage;
    [SerializeField] bool hasKey;
    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPosition;
    // Start is called before the first frame update

    IEnumerator PlayerCoroutine()
    {
        
        yield return new WaitForSeconds(.1f);

        //spawnPosition = player.transform;
        player.transform.position = spawnPosition.position;
        
        scoreManager.SetScore(10000);
    }

    void Start()
    {
        GameStart();  

        //SetKey(true);
        DontDestroyOnLoad(this.gameObject);
    }


    void GameStart()
    {
        scoreText.text = "0";
        player.GetComponent<PlayerInventory>().SetKey(false, Color.white);
        player.GetComponent<PlayerInventory>().AddAmmo(3);
        //scoreManager.LoadData();
    }

  
    // Update is called once per frame
    void Update()
    {
        SetScoreText();
        SetAmmoText();
        PlayerDeath();
        if (ammoText == null || inventory == null)
        {
            ammoText = GameObject.Find("AMMO Text").GetComponent<Text>();
            scoreText = GameObject.Find("Score Text").GetComponent<Text>();
            keyImage = GameObject.Find("Key Image").GetComponent<Image>();
            inventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        }
        if (spawnPosition == null)
        {
            spawnPosition = GameObject.FindWithTag("SpawnPosition").transform;
        }
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            LevelComplete();
            print("Hellow");
        }
    }
    void PlayerDeath()
    {
        if (player.GetComponent<PlayerInventory>().GetHealth() <= 0)
        {
            player.transform.position = spawnPosition.localPosition;
            
            player.GetComponent<PlayerInventory>().AddHealth(100);
            player.GetComponent<PlayerInventory>().AddAmmo(3);
        }

    }
    void SetScoreText()
    {
        scoreText.text = scoreManager.GetScore().ToString();
    }

    void SetAmmoText()
    {
        ammoText.text = inventory.GetAmmo().ToString() + "/3";
    }
   
    public void LevelComplete()
    {
        int nextScene = 0;
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        inventory.AddHealth(100);
        SceneManager.LoadScene(nextScene);
        
        print(nextScene);
        scoreManager.SaveFile();
        
        StartCoroutine(PlayerCoroutine());
        GameStart();
        
        
     }
}
