using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item_AttackPower : Item
{

    protected override void GiveItem()
    {
        base.GiveItem();
        playerStatItem.playerClass.attackPower += 10;
    }
}
