using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBestiaryDisplay : MonoBehaviour
{
    [SerializeField]
    private Image entryImage;
    [SerializeField]
    private TMP_Text entryTitle;
    // Start is called before the first frame update
    private void Awake()
    {
        ResetDisplay();
    }

    public void SetDisplay(string entryTitle, Sprite entryImage)
    {
        this.entryTitle.text = entryTitle;
        this.entryImage.sprite = entryImage;
    }

    public void ResetDisplay()
    {
        this.entryTitle.text = "";
        this.entryImage.gameObject.SetActive(false);
    }
}
