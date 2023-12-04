using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestiaryController : MonoBehaviour
{
    [SerializeField]
    private UIBestiaryPage bestiaryUI;

    public int bestiaryEntrySizes = 30;


    //MOCK UP
    Sprite sprite;


    private void Start()
    {
        PrepareUI();
    }

    private void PrepareUI()
    {
        bestiaryUI.InitializeBestiary(bestiaryEntrySizes);
        this.bestiaryUI.OnDescriptionRequested += HandleDescriptionRequest;
        this.bestiaryUI.OnDisplayRequested += HandleDisplayRequest;
    }

    public void Update()
    {
        BestiaryVisibility();
    }


    private void HandleDescriptionRequest(int entryIndex)
    {
        bestiaryUI.UpdateDescription(entryIndex, "TESTING TESTING !");
    }

    private void HandleDisplayRequest(int entryIndex)
    {

    }





    private void BestiaryVisibility()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (bestiaryUI.isActiveAndEnabled)
            {
                TimeManager.Instance.ResumeTime();
                bestiaryUI.HideBestiary();
            }
            else
            {
                TimeManager.Instance.StopTime();
                bestiaryUI.ShowBestiary();
            }
        }
    }
}
