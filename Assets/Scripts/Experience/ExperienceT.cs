using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceT : MonoBehaviour
{
    //public for now 
    public int currentExperience;
    public int maxExperience;

    [SerializeField]
    protected ExperienceBar expBar;

    private void Update()
    {

            expBar.SetExperience(currentExperience);
            expBar.SetNextLevelExp(maxExperience);
        
    }

    public void Increase(int amount)
    {
        Debug.Log(currentExperience);
        Debug.Log(amount);
        currentExperience += amount;
        Debug.Log(currentExperience);
    }

    public void ResetExp()
    {
        currentExperience = 0;
    }

    public void IncreaseMax(int amount)
    {
        maxExperience = amount;
    }

    public int GetCurrentExperience()
    {
        return currentExperience;
    }

    public int GetMaxExperience()
    {
        return maxExperience;
    }

    public int GetCustomExperience(int amount)
    {
        return currentExperience + amount;
    }

    public void SetCurrentExperience( int amount)
    {
        currentExperience = amount;
    }
}
