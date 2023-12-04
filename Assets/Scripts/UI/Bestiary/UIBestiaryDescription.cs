using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIBestiaryDescription : MonoBehaviour
{
    [SerializeField]
    private TMP_Text description;
    // Start is called before the first frame update
    private void Awake()
    {
        ResetDescription();
    }

    public void ResetDescription()
    {
        description.text = "";
    }

    public void SetDescription(string description)
    {
        this.description.text = description;
    }
}
