using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField]
    private SaveSlotsMenu saveSlotsMenu;

    [SerializeField]
    private Button continueButton;
    private void Start()
    {
        if ( !DataPersistanceManager.instance.HasData() )
        {
            continueButton.interactable = false;
        }
        else
        {
            continueButton.interactable = true;
        }
    }
    public void StartGame()
    {
        saveSlotsMenu.ActivateMenu(false);
        this.DeactivateMenu();
    }

    public void OnLoadGameClicked()
    {
        saveSlotsMenu.ActivateMenu(true);
        this.DeactivateMenu();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void ActivateMenu()
    {
        this.gameObject.SetActive(true);
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }
}
