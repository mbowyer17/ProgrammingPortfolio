using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TheGameManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] PlayerInventory inventory;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab);
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<PlayerInventory>();
     
    }


    // Update is called once per frame
    void Update()
    {
        

        if (inventory.GetHealth() <= 0)
        {
       
            SceneManager.LoadScene("GameOver");
        }
    }
}
