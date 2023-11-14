using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Change to PlayerController?
    protected Player_Movement playerStatItem;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            playerStatItem = other.GetComponent<Player_Movement>();
            GiveItem();
            OnDestroy();
        }
    }

    protected virtual void GiveItem()
    {
        
    }
    void OnDestroy()
    {
        Destroy(gameObject);
    }
}
