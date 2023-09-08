using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{

    protected PlayerInventory inventory;
    [SerializeField] protected AudioManager audioManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        inventory = collision.gameObject.GetComponent<PlayerInventory>(); 
        
        if (inventory != null )
        {
            
            onDestroy();
            GiveItem();
        }
    }
 

    protected virtual void GiveItem()
    {
        
    }
    protected void onDestroy()
    {
        
        Destroy(gameObject);
    }
}
