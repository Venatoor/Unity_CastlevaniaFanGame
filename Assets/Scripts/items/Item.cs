using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [field: SerializeField]
    public ItemData itemData;

    
}
public enum ItemType
{
    OnPickUp, OnInteraction, Both,
}