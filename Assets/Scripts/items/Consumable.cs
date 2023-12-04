using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumable : Item
{
    private void Start()
    {
        itemData.canbeAddedToInventory = true;
        itemData.isDestructible = true;
        itemData.itemType = ItemType.Both;


        itemData.maxStackSize = 99;
    }
    public abstract void OnUsage(Character character);
}
