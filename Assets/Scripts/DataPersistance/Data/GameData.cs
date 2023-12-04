using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    #region CharacterStats
    public int playerExperience;
    public int playerHealth;
    public int playerLevel;
    public int playerDamage;
    public int playerNeededExperience;
    public int playerMaxHealth;
    #endregion

    #region AbilitiesUnlocks
    public bool playerDashUnlock;
    public bool playerDoubleJumpUnlock;
    #endregion

    //This constructor serves as the default values when a player begins the game
    public GameData()
    {
        this.playerExperience = 0;
        this.playerNeededExperience = 100;
        this.playerHealth = 100;
        this.playerMaxHealth = 100;
        this.playerDamage = 0; // will be reattributed in Weapon script 

        this.playerDashUnlock = false;
        this.playerDoubleJumpUnlock = false;

    }
}
