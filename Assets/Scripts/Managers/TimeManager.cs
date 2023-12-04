using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Managers
{
    private bool isPaused;

    [Header("Time attributes")]
    private float elapsedGameTime;
    public float convertedGameTime;
    public int elapsedHour;
    public int elapsedMin;

    private static TimeManager instance;

    public static TimeManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("TimeManager");
                obj.AddComponent<TimeManager>();
            }
            return instance;
        }
    }
    private void Start()
    {
        elapsedGameTime = 0;
    }

    private void Awake()
    {
        Time.timeScale = 1f;
        if ( instance == null )
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        CalculateGameTime();
    }

    private void CalculateGameTime()
    {

        elapsedGameTime += Time.deltaTime;
        convertedGameTime = (int)elapsedGameTime;

        elapsedMin = (int)convertedGameTime / 60;
        elapsedHour = (int)convertedGameTime / 3600;
    }

    public void StopTime() 
    {
        Debug.Log("The game is paused !");
        Time.timeScale = 0;
        isPaused = true;
    }

    public void ResumeTime()
    {
        Debug.Log("The game is unpaused!");
        Time.timeScale = 1;
        isPaused = false;
    }

    public bool GetCurrentTimeState()
    {
        return isPaused;
    }
}
