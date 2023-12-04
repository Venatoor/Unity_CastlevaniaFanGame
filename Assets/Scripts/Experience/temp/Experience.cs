using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour, IDataPersistance
{
    [SerializeField]
    protected int experienceNeeded;
    public int currentExperience;
    protected Character character;
    protected GameObject player;
    protected PlayerHealth health;
    protected Weapon weapon;
    private int experienceGainedRemaining;
    private int overExperience;


    private void Start()
    {
        player = FindObjectOfType<Character>().gameObject;
        character = player.GetComponent<Character>();
        health = player.GetComponent<PlayerHealth>();
        weapon = player.GetComponent<Weapon>();

    }


    // Experience 
    // Start is called before the first frame update
    public void GiveExperience(int amount)
    {
        overExperience = currentExperience + amount;
        if ( overExperience > experienceNeeded )
        {
            experienceGainedRemaining = overExperience - experienceNeeded;
            currentExperience += overExperience - currentExperience;
            LevelUp();
            currentExperience += experienceGainedRemaining;

        } 
        else
        {
            currentExperience += amount;
            if ( currentExperience == experienceNeeded )
            {
                LevelUp();
            }
        }
    }

    protected virtual void LevelUp()
    {
        currentExperience = 0;
        experienceNeeded *= 2;

        AudioManager.instance.playAudio(AudioManager.instance.levelUp);
        Debug.Log("Leveled up !");
        //for testing only
        health.maxHealthPoints += 20;
        weapon.IncreaseWeaponDamage();

    }

    public void LoadData(GameData data)
    {
        //weapon.damage = data.playerDamage;
        currentExperience = data.playerExperience;
        experienceNeeded = data.playerNeededExperience;
    }

    public void SaveData(ref GameData data)
    {
        data.playerDamage = weapon.damage;
        data.playerExperience = currentExperience;
        data.playerNeededExperience = experienceNeeded;
    }
}
