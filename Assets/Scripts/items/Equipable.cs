using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipable : Item
{
    // Start is called before the first frame update
    void Start()
    {
        itemData.canbeAddedToInventory = true;
        itemData.isDestructible = true;
        itemData.itemType = ItemType.Both;

        itemData.maxStackSize = 99;
    }


    public abstract void OnEquip();


}
