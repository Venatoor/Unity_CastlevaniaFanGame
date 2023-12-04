using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health, IDataPersistance
{

    public FloatValueSO currentHealth;

    [SerializeField]
    private HealthBar healthSlider;

    public bool left;
    public bool invincibility;
    protected float damageKnockbackH = 80;
    protected float damageKnockbackV = 110;
    public GameObject projectileIncoming;
    // Start is called before the first frame update
    protected override void Initialization()
    {
        rb = GetComponent<Rigidbody2D>();
        if ( currentHealth.Value == maxHealthPoints )
        {
            currentHealth.Value = maxHealthPoints;
        }

    }

    private void Update()
    {
        HealthPoints = currentHealth.Value;
        healthSlider.SetHealth(currentHealth.Value);
        healthSlider.SetMaxHealth(maxHealthPoints);
    }

    void IDataPersistance.LoadData(GameData data)
    {
        maxHealthPoints = data.playerMaxHealth;
        currentHealth.Value = data.playerHealth;
    }

    void IDataPersistance.SaveData(ref GameData data)
    {
        data.playerMaxHealth = maxHealthPoints;
        data.playerHealth = currentHealth.Value;
    }


    //Main Health Methods and Functionalities

    public override void Increase(int amount)
    {
        //Checking if HealthPoints not depassing MaxHealthPoints
        if (!(maxHealthPoints <= currentHealth.Value))
        {
            currentHealth.Value += amount;
        }
        else if (HealthPoints + amount > maxHealthPoints)
        {
            currentHealth.Value += maxHealthPoints;
        }
    }

    public override void Reduce(int amount)
    {
        gameObject.GetComponent<Character>().isHit = true;
            currentHealth.Value -= amount;
        
    }

    public override void IncreaseMaxHealth(int amount)
    {
        maxHealthPoints += amount;
        currentHealth.Value = maxHealthPoints;
    }

    public void ResetHealth()
    {
        currentHealth.Value = maxHealthPoints;
    }
}
