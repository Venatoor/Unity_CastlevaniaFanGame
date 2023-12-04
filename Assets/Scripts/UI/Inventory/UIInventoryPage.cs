using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField]
    private UIInventoryItem itemPrefab;
    [SerializeField]
    private RectTransform contentPanel;

    [SerializeField]
    private MouseFollower mouseFollower;

    [SerializeField]
    private UIInventoryDescription itemDescription;

    List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

    //MOCKING_DATA_SO_INVENTORY
    public Sprite image, image2;
    public int quantity;
    public string name, description;

    //Events 2
    public event Action<int> OnDescriptionRequested, OnStartDragging, OnItemActionRequested;
    public event Action<int, int> OnSwapItems;
    //END

    private int currentlyDraggedItemIndex = -1;

    private void Awake()
    {
        HideInventory();
        mouseFollower.Toggle(false);
        itemDescription.ResetDescription();
    }

    internal void ResetAllItems()
    {
        foreach ( var item in listOfUIItems )
        {
            item.ResetData();
            item.Deselect();
        }
    }

    public void InitializeInventory(int inventorySize)
    {
        for ( int i =0; i<inventorySize; i++)
        {
            UIInventoryItem inventoryItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            inventoryItem.transform.SetParent(contentPanel);
            listOfUIItems.Add(inventoryItem);
            inventoryItem.OnItemClicked += HandleItemSelection;
            inventoryItem.OnItemBeginDrag += HandleBeginDrag;
            inventoryItem.OnItemDroppedOn += HandleSwap;
            inventoryItem.OnItemEndDrag += HandleEndDrag;
            inventoryItem.OnRightMouseBtnClick += HandleShowItemAction;
        }
    }

    internal void UpdateDescription(int itemIndex, Sprite image, string name, string description)
    { 
        itemDescription.SetDescription(image, name, description);
        DeselectAllItems();
        listOfUIItems[itemIndex].Select();
    }

    public void UpdateData(int itemIndex, Sprite itemImage, int itemQuantity )
    {
        if ( listOfUIItems.Count > itemIndex )
        {
            listOfUIItems[itemIndex].SetData(itemImage, itemQuantity);
        }
    }

    private void HandleShowItemAction(UIInventoryItem inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        if (index == -1)
        {

            return;
        }
        OnItemActionRequested?.Invoke(index);
    }

    private void HandleEndDrag(UIInventoryItem inventoryItemUI)
    {
        mouseFollower.Toggle(false);
        //ON handleEndDrag is always called after handleswap
        ResetDraggedItem();
    }

    private void HandleSwap(UIInventoryItem inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        if ( index == -1 )
        {
            
            return;
        }
        OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
        HandleItemSelection(inventoryItemUI);
    }

    private void ResetDraggedItem()
    {
        mouseFollower.Toggle(false);
        currentlyDraggedItemIndex = -1;
    }

    private void HandleBeginDrag(UIInventoryItem inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        if ( index == -1)
        {
            return;
        }
        currentlyDraggedItemIndex = index;
        HandleItemSelection(inventoryItemUI);
        OnStartDragging?.Invoke(index);
    }

    public void CreateDraggedItem(Sprite sprite, int quantity)
    {
        // implementing the dragging using the mouseFollower script
        mouseFollower.Toggle(true);
        // Setting the image and sprite used when the Filled inventory slot is moved
        mouseFollower.SetData(sprite, quantity);
    }

    private void HandleItemSelection(UIInventoryItem inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        if ( index == -1 )
        {
            return;
        }
        OnDescriptionRequested?.Invoke(index);
    }

    public void HideInventory()
    {
        gameObject.SetActive(false);
        ResetDraggedItem();
    }

    public void ShowInventory()
    {
        gameObject.SetActive(true);
        itemDescription.ResetDescription();
        ResetSelection();


    }

    public void ResetSelection()
    {
        itemDescription.ResetDescription();
        DeselectAllItems();
    }

    private void DeselectAllItems()
    {
        foreach ( UIInventoryItem item in listOfUIItems )
        {
            item.Deselect();
        }
    }
}
