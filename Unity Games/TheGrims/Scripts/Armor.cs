using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Armor : CollectableItem
{
    [SerializeField]int armorAmount;
 

    protected override void GiveItem()
    {
        inventory.AddArmor(armorAmount);
        audioManager.AudioPickupSound();
    }
}
