using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    private void Awake()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }

    protected virtual void Pause() { 
        if ( Input.GetKeyDown(KeyCode.T) )
        {
            Debug.Log("key pressed");
            if ( pauseMenu.activeInHierarchy )
            {
                pauseMenu.SetActive(false);
                TimeManager.Instance.ResumeTime();
            }
           else
            {
                pauseMenu.SetActive(true);
                TimeManager.Instance.StopTime();
            }
        }
    
    }
}