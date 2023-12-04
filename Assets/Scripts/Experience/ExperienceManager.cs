using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ExperienceManager : MonoBehaviour
{
    public ExperienceT playerExperience;
    public int overExperience;
    public int excessiveExperience;

    public bool isExperienceHeightReached;

    public event Action<ExperienceManager> OnMaxCurrentExperience;

    private void Start()
    {
        playerExperience = FindObjectOfType<Character>().GetComponent<ExperienceT>();
        isExperienceHeightReached = false;
    }
    public void GiveExperience(int amount)
    {
        
        overExperience = playerExperience.GetCurrentExperience() + amount;
        if ( overExperience > playerExperience.GetMaxExperience())
        {
            
            playerExperience.SetCurrentExperience(playerExperience.GetMaxExperience());
            StoreExcessiveExperience(overExperience - playerExperience.GetMaxExperience());
            OnMaxCurrentExperience?.Invoke(this);
            
        }
        else
        {
            playerExperience.Increase(amount);
        }
    }

    public void StoreExcessiveExperience(int amount) // Setter
    {
        excessiveExperience = amount;
    }

    public void GiveExcessiveExperience()
    {
        playerExperience.currentExperience += excessiveExperience;
    }

    public void RemoveExcessiveExperience()
    {
        excessiveExperience = 0;
    }

    public int CalculateNewRequiredExperience(int x) 
    {
        return HyperbolaFunction(x);
    }

    public void ResetExperience()
    {
        playerExperience.ResetExp();
    }

    public int HyperbolaFunction(int x)
    {
        return (int)(2 * x + 5 * Mathf.Pow(x, 2) + 3 * Mathf.Pow(x, 3));
    }


    public void IncreaseMaxExperience(int amount)
    {
        playerExperience.IncreaseMax(amount);
    }
}
