using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : CollectableItem
{
    [SerializeField] int ammoAmount;
    
    protected override void GiveItem()
    {
        inventory.AddAmmo(ammoAmount);
        audioManager.AudioPickupSound();
    }
}
