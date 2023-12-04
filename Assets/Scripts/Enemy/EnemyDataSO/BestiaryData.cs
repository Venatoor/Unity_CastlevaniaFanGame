using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BestiaryData : ScriptableObject
{
    public Sprite enemySprite;
    public string description;
    public float health;

    public List<Affinities> resistances;
    public List<Affinities> weaknesses;

    public int experienceGiven;
    public int enemyId;
    public string enemyName;

    public EnemyType enemyType;



   
}


public enum EnemyType
{
    BOSS,POISED,NORMAL
}
