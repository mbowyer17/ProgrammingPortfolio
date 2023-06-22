using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : CollectableItem
{
    [SerializeField] int healthAmount;

    protected override void GiveItem()
    {
        inventory.AddHealth(healthAmount);
        audioManager.AudioPickupSound();
    }
}
