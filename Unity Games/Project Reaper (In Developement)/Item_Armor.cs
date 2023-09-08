using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Armor : Item
{
    // Start is called before the first frame update
    protected override void GiveItem()
    {
        base.GiveItem();
        playerStatItem.playerClass.armor += 10;
    }
}
