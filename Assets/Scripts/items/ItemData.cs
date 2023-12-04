using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject
{
    public int ID => GetInstanceID();

    public ItemType itemType;

    public string itemName { get; set; }

    public int maxStackSize { get; set; }

    public int quantity { get; set; }

    [field: SerializeField]
    [field: TextArea]
    public string description { get; set; }

    [field: SerializeField]
    public Sprite image {get; set;}

    [field: HideInInspector]
    public bool canbeAddedToInventory { get; set; }

    public bool isDestructible;
}
