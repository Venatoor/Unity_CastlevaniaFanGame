using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBestiaryPage : MonoBehaviour
{
    [SerializeField]
    private UIBestiaryEntries entryPrefab;
    [SerializeField]
    private RectTransform contentPanel;

    [SerializeField]
    private UIBestiaryDisplay bestiaryDisplay;
    [SerializeField]
    private UIBestiaryDescription bestiaryDescription;
    
    public event Action<int> OnDescriptionRequested, OnDisplayRequested;

    List<UIBestiaryEntries> bestiaryEntries = new List<UIBestiaryEntries>();



    public int currentSelectedEntry = -1;

    // Start is called before the first frame update


    private void Awake()
    {
        HideBestiary();
    }

    private void Update()
    {
        HandleEntrySelectionDown();
        HandleEntrySelectionUp();
    }

    public void InitializeBestiary(int bestiaryEntriesSize)
    {
        for ( int i =0; i<bestiaryEntriesSize; i++)
        {
            UIBestiaryEntries bestiaryEntry = Instantiate(entryPrefab, Vector3.zero, Quaternion.identity);
            bestiaryEntry.transform.SetParent(contentPanel);
            bestiaryEntries.Add(bestiaryEntry);



        }
    }

    public void UpdateDisplay(int entryIndex, string entryTitle, Sprite entryImage)
    {
        bestiaryDisplay.SetDisplay(entryTitle, entryImage);
        DeselectAllEntries();
    }

    public void UpdateDescription(int entryIndex , string description)
    {
        bestiaryDescription.SetDescription(description);
        DeselectAllEntries();
        bestiaryEntries[entryIndex].Select();
    }

    public void HideBestiary() 
    {
        gameObject.SetActive(false);
    }

    public void ShowBestiary()
    {
        gameObject.SetActive(true);
        bestiaryDescription.ResetDescription();
        bestiaryDisplay.ResetDisplay();
    }


    public void ResetSelection()
    {
        bestiaryDescription.ResetDescription();
    }

    private void DeselectAllEntries()
    {
        foreach ( UIBestiaryEntries bestiaryEntry in bestiaryEntries)
        {
            bestiaryEntry.Deselect();
        }
    }


    private void HandleEntrySelectionUp()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentSelectedEntry == -1)
            {
                currentSelectedEntry++;
            }
            if (currentSelectedEntry == 0)
            {
                return;
            }
            else if ( currentSelectedEntry != 0 || currentSelectedEntry != -1)
            {
                currentSelectedEntry--;
            }
            OnDescriptionRequested?.Invoke(currentSelectedEntry);
            OnDisplayRequested?.Invoke(currentSelectedEntry);
            //TEMP CODE
        }
    }

    private void HandleEntrySelectionDown()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentSelectedEntry == -1)
            {
                currentSelectedEntry++;
            }
            if (currentSelectedEntry == bestiaryEntries.Count-1)
            {
                return;
            }
            else if ( currentSelectedEntry != bestiaryEntries.Count-1 || currentSelectedEntry != 0)
            {
                currentSelectedEntry++;
            }
            OnDescriptionRequested?.Invoke(currentSelectedEntry);
            OnDisplayRequested?.Invoke(currentSelectedEntry);
        }
        //TEMP CODE
    }



}
