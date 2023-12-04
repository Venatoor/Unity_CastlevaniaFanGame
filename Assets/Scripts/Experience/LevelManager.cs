using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public ExperienceManager experienceManager;
    public Level playerLevel;

    public int newRequiredExp;

    private void Start()
    {
        experienceManager = FindObjectOfType<ExperienceManager>();
        playerLevel = FindObjectOfType<Level>();
    }


    private void OnEnable()
    {
        experienceManager.OnMaxCurrentExperience += HandleLevelUp;
    }

    public void HandleLevelUp(ExperienceManager experienceManager)
    {
        experienceManager.ResetExperience();
        playerLevel.IncreaseLevel();
        //Stats
        newRequiredExp = experienceManager.CalculateNewRequiredExperience(playerLevel.GetNextLevel(playerLevel.GetLevel()));
        experienceManager.IncreaseMaxExperience(newRequiredExp);
        experienceManager.GiveExcessiveExperience();
        experienceManager.RemoveExcessiveExperience();
    }

    public Level GetLevel()
    {
        return playerLevel;
    }

}
