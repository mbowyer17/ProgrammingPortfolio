using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : CollectableItem
{
    
    protected override void GiveItem()
    {
        inventory.SetKey(true, Color.green);
        print("Got Ket");
    }
}
