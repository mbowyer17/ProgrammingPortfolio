using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] TheGameManager tgm;
    [SerializeField] PlayerInventory player;

    private void Awake()
    {
        if (tgm == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
            tgm = GameObject.Find("TheGameManagerObject").GetComponent<TheGameManager>();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player" && player.GetKey() == true)
        {
            tgm.LevelComplete();
        }
    }
}
