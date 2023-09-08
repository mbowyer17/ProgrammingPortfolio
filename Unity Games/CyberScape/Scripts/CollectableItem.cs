using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    protected PlayerInventory inventory;

    private void OnTriggerEnter(Collider collision)
    {
        inventory = collision.gameObject.GetComponent<PlayerInventory>();
        if (inventory != null)
        {
            onDestroy();
            GiveItem();
        }
    }
    private void onDestroy()
    {
        Destroy(this.gameObject);
    }
    
    protected virtual void GiveItem()
    {

    }
}
