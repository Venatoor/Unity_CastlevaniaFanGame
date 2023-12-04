using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class InventorySO : ScriptableObject
{
    [SerializeField]
    public List<InventoryItem> inventoryItems;

    [field: SerializeField]
    public int size { get; private set; } = 10;

    public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;

    public void Initialize()
    {
        inventoryItems = new List<InventoryItem>();
        for ( int i =0; i< size; i++)
        {
            inventoryItems.Add(InventoryItem.GetEmptyItem());
        }
    }

    public int AddItem(ItemSO item, int quantity)
    {
        if (!item.IsStackable)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                while(quantity > 0 && IsInventoryFull() == false)
                {
                    quantity -= AddNonStackableItem(item, 1);
                }
                InformAboutChange();
                return quantity;
            }
        }
        quantity = AddStackableItem(item, quantity);
        InformAboutChange();
        return quantity;
    }

    private int AddNonStackableItem(ItemSO item, int quantity)
    {
        InventoryItem newItem = new InventoryItem
        {
            item = item,
            quantity = quantity,
        };

        for (int i = 0; i < inventoryItems.Count; i++ )
        {
            if ( inventoryItems[i].isEmpty )
            {
                inventoryItems[i] = newItem;
                return quantity;
            }
        }
        return 0;
    }

    public bool IsInventoryFull() => inventoryItems.Where(item => item.isEmpty).Any() == false;

    public void RemoveItem(int itemIndex, int amount)
    {
        if (inventoryItems.Count > itemIndex)
        {
            if (inventoryItems[itemIndex].isEmpty)
                return;
            int reminder = inventoryItems[itemIndex].quantity - amount;
            if (reminder <= 0)
                inventoryItems[itemIndex] = InventoryItem.GetEmptyItem();
            else
                inventoryItems[itemIndex] = inventoryItems[itemIndex]
                    .ChangeQuantity(reminder);

            InformAboutChange();
        }
    }

    private int AddStackableItem(ItemSO item, int quantity)
    {
        for ( int i = 0; i < inventoryItems.Count; i++ )
        {
            if ( inventoryItems[i].isEmpty )
                continue;
            if (inventoryItems[i].item.ID == item.ID)
            {
                int amountPossibleToTake = inventoryItems[i].item.MaxStackSize - inventoryItems[i].quantity;

                if (quantity > amountPossibleToTake)
                {
                    inventoryItems[i] = inventoryItems[i].ChangeQuantity(inventoryItems[i].item.MaxStackSize);
                    quantity -= amountPossibleToTake;
                }
                else
                {
                    inventoryItems[i] = inventoryItems[i].ChangeQuantity(inventoryItems[i].quantity + quantity);
                    InformAboutChange();
                    return 0;
                }
            
            }
        }
        while ( quantity > 0 && IsInventoryFull() == false)
        {
            int newQuantity = Mathf.Clamp(quantity, 0, item.MaxStackSize);
            quantity -= newQuantity;
            AddItemToFirstFreeSlot(item, newQuantity);

        }
        return quantity;
    }

    private int AddItemToFirstFreeSlot(ItemSO item, int newQuantity)
    {
        InventoryItem newItem = new InventoryItem
        {
            item = item,
            quantity = newQuantity,
        };
        for ( int i =0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].isEmpty)
            {
                inventoryItems[i] = newItem;
                return newQuantity;
            }
        }
        return 0;

    }
    

    internal void AddItem(InventoryItem item)
    {
        AddItem(item.item, item.quantity);
    }

    public Dictionary<int, InventoryItem> GetCurrentInventoryState()
    {
        Dictionary<int, InventoryItem> returnValue = new Dictionary<int, InventoryItem>();
        for ( int i =0; i < inventoryItems.Count; i++)
        {
            if ( inventoryItems[i].isEmpty)
            {
                continue;
            }
            returnValue[i] = inventoryItems[i];

        }
        return returnValue;
    }

    internal InventoryItem GetItemAt(int itemIndex)
    {
        return inventoryItems[itemIndex];
    }

    internal void SwapItems(int itemIndex1, int itemIndex2)
    {
        InventoryItem item1 = inventoryItems[itemIndex2];
        inventoryItems[itemIndex2] = inventoryItems[itemIndex1];
        inventoryItems[itemIndex1] = item1;
        InformAboutChange();
    }

    private void InformAboutChange()
    {
        OnInventoryUpdated?.Invoke(GetCurrentInventoryState());
    }
}

[Serializable]
public struct InventoryItem
{
    public int quantity;
    public ItemSO item;

    public bool isEmpty => item == null;


    public InventoryItem ChangeQuantity(int newQuantity)
    {
        return new InventoryItem
        {
            item = this.item,
            quantity = newQuantity,
        };
    }

    public static InventoryItem GetEmptyItem() => new InventoryItem
    {
        item = null,
        quantity = 0,
    };
}


