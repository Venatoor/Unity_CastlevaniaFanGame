using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private UIInventoryPage inventoryUI;

    [SerializeField]
    private InventorySO inventoryData;

    public List<InventoryItem> initalItems = new List<InventoryItem>();

    private void Start()
    {
        PrepareUI();
        PrepareInventoryData();
    }

        private void PrepareInventoryData()
        {
            inventoryData.Initialize();
            inventoryData.OnInventoryUpdated += UpdateInventoryUI;
            foreach ( InventoryItem item in initalItems)
            {
                if ( item.isEmpty)
                    continue;
                inventoryData.AddItem(item);
                
            }
        }
    

    private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
    {
        inventoryUI.ResetAllItems();
        foreach ( var item in inventoryState )
        {
            inventoryUI.UpdateData(item.Key, item.Value.item.Image, item.Value.quantity);

        }
    }

    private void PrepareUI()
    {
        inventoryUI.InitializeInventory(inventoryData.size);
        this.inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
        this.inventoryUI.OnSwapItems += HandleSwapItems;
        this.inventoryUI.OnStartDragging += HandleDrag;
        this.inventoryUI.OnItemActionRequested += HandleItemActionRequested;
    }

    private void HandleItemActionRequested(int itemIndex)
    {
        InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
        if (inventoryItem.isEmpty)
            return;

        IItemAction itemAction = inventoryItem.item as IItemAction;
        if ( itemAction != null)
        {
            itemAction.PerformAction(gameObject);
        }

        IDestroyableItem itemDestruction = inventoryItem.item as IDestroyableItem;
        if ( itemDestruction != null )
        {
            inventoryData.RemoveItem(itemIndex, 1);
        }
    }



    private void HandleDrag(int itemIndex)
    {
        InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
        if ( inventoryItem.isEmpty)
        {
            return;
        }
        inventoryUI.CreateDraggedItem(inventoryItem.item.Image, inventoryItem.quantity);
    }

    private void HandleSwapItems(int itemIndex1, int itemIndex2)
    {
        inventoryData.SwapItems(itemIndex1, itemIndex2);
    }

    private void HandleDescriptionRequest(int itemIndex)
    {
        InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
        if (inventoryItem.isEmpty)
        {
            inventoryUI.ResetSelection();
            return;
        }
        ItemSO item = inventoryItem.item;
        inventoryUI.UpdateDescription(itemIndex, item.Image, item.name, item.Description);
    }

    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.I))
        {
            if(inventoryUI.isActiveAndEnabled == false )
            {
                inventoryUI.ShowInventory();
                TimeManager.Instance.StopTime();
                foreach ( var item in inventoryData.GetCurrentInventoryState())
                {
                    inventoryUI.UpdateData(item.Key, item.Value.item.Image, item.Value.quantity);
                }
            }
            else
            {
                inventoryUI.HideInventory();
                TimeManager.Instance.ResumeTime();
            }
        }
    }

}
