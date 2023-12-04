using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    protected Character character;
    protected GameObject player;
    protected EnemyHealth enemyHealth;
    public int damageOnContact;

    private BestiaryData enemyData;


    //temp
    public ExperienceManager experienceManager;
    //endtemp

    public Collider2D[] playerRange;
    [SerializeField]
    protected GameObject deathEffect;


    [Header("EnemyData")]
    private float dataHealth;
    private int dataExperience;

    private List<Affinities> dataResistances;
    private List<Affinities> dataWeaknesses;

    private EnemyType dataEnemyType;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Character>().gameObject;
        character = player.GetComponent<Character>();
        enemyHealth = GetComponent<EnemyHealth>();
        experienceManager = FindObjectOfType<ExperienceManager>().GetComponent<ExperienceManager>();

        LoadData();
        
    }
    // Update is called once per frame
    private void Update()
    {
        Death();
    }


    


    public void TakeHit(int damage, Affinities affinity)
    {
        // Going through damage manager, checking affinities and type of damage received from weapon or spell.
        int finalDamage = DamageManager.Instance.ManageEnemyDamage(damage, affinity, this);
        enemyHealth.Reduce(finalDamage); // should be finalDamage here
    }

    public void Death()
    {
        if ( enemyHealth.HealthPoints <= 0 )
        {
            enemyHealth.HealthPoints = 0;
            gameObject.SetActive(false);
            //Instantiate(deathEffect, transform.position, Quaternion.identity);
            experienceManager.GiveExperience(dataExperience);

        }
    }

    public void Ressurect()
    {
        if ( !gameObject.activeSelf )
        {
            enemyHealth.HealthPoints = enemyHealth.maxHealthPoints;
            gameObject.SetActive(true);
        }
    }


    private void LoadData()
    {
        dataExperience = enemyData.experienceGiven;
        dataHealth = enemyData.health;
        dataResistances = enemyData.resistances;
        dataWeaknesses = enemyData.weaknesses;
        dataEnemyType = enemyData.enemyType;
    }


    public List<Affinities> GetWeaknesses()
    {
        return dataWeaknesses;
    }

    public List<Affinities> GetResistances()
    {
        return dataResistances;
    }
}
