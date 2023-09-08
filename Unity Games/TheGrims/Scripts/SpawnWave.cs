using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    [SerializeField] List<WavesManager> firstWave = new List<WavesManager>();
    [SerializeField] List<WavesManager> secondWave = new List<WavesManager>();
    [SerializeField] List<WavesManager> bossWave = new List<WavesManager>();
    [SerializeField] List<GameObject> enemies;

    [SerializeField]float timer, bTimer;
    
    float spawnTimer = 15f;
    float bossTimer = 45f;
    // Start is called before the first frame update
  
    void Start()
    {
        timer = spawnTimer;
        bTimer = bossTimer;
        FirstWave();
        
    }

    void FirstWave()
    {
        firstWave.Add(new SpawnOne());
        firstWave.Add(new SpawnTwo());
        firstWave.Add(new SpawnThree());
        firstWave.Add(new SpawnFour());

        foreach (WavesManager i in firstWave)
        {

            i.WaveMessage();

            //int randomNumber = Random.Range(0, 2);
            //print(randomNumber);
            GameObject clone = Instantiate(enemies[0]);
            clone.transform.position = new Vector3(i.SpawnPositonX(), i.SpawnPositonY());

        }
    }

    void SecondWave()
    {
        secondWave.Add(new SpawnOne());
        secondWave.Add(new SpawnTwo());
        secondWave.Add(new SpawnThree());
        secondWave.Add(new SpawnFour());
        secondWave.Add(new SpawnFive());
        secondWave.Add(new SpawnSix());

        foreach (WavesManager i in secondWave)
        {

            i.WaveMessage();

            int randomNumber = Random.Range(0, 2);
            
            GameObject clone = Instantiate(enemies[randomNumber]);
            clone.transform.position = new Vector3(i.SpawnPositonX(), i.SpawnPositonY());

        }
    }

    void BossWave()
    {
        bossWave.Add(new SpawnBoss());

        foreach (WavesManager i in bossWave)
        {

            i.WaveMessage();

            

            GameObject clone = Instantiate(enemies[2]);
            clone.transform.position = new Vector3(i.SpawnPositonX(), i.SpawnPositonY());

        }
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        bTimer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = spawnTimer;
            SecondWave();
        }
        if (bTimer < 0)
        {
            bTimer = bossTimer;
            BossWave();
        }
      

    }
}

