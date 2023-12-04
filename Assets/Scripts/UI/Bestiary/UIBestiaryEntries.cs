using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIBestiaryEntries : MonoBehaviour
{
    [SerializeField]
    private Image borderImage;
    [SerializeField]
    private TMP_Text entryName;


    private bool locked = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Deselect();
        //NOT TO FORGET TO INCLUDE A SORT 
    }


    public void Select()
    {
        borderImage.enabled = true;
    }

    public void Deselect()
    {
        borderImage.enabled = false;
    }

    public void Unlock(string entryName) 
    {
        this.entryName.text = entryName;
        this.locked = false;
    }

    //Here lies events




    
}
