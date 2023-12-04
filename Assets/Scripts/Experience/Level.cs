using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int currentLevel;
    private void Start()
    {
        currentLevel = 1;
    }
    public void IncreaseLevel()
    {
        currentLevel++;
    }



    public int GetLevel()
    {
        return currentLevel;
    }

    public int GetNextLevel(int amount)
    {
        return amount++;
    }
}
