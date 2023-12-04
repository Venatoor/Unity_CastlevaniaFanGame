using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : Managers
{
    public int maxHealthPoints = 100;
    
    public int HealthPoints;
    [SerializeField]
    protected float iFrameTime = 0.3f;    // Has nothing to do with health but rather with sprite
    public bool hit;
    protected Rigidbody2D rb;

    // Start is called before the first frame update
    protected override void Initialization()
    {
        base.Initialization();
        rb = GetComponent<Rigidbody2D>();
        if (HealthPoints == maxHealthPoints || gameObject.CompareTag("Enemy")) // For Data scripts
        {
            HealthPoints = maxHealthPoints;
        }
       
    }

    

    protected  void Cancel()
    {
        hit = false;
        character.canMove = true;
    }

    public virtual void Reduce( int amount)
    {
       
            character.canMove = false;
            HealthPoints -= amount;
            hit = true;
            Invoke("Cancel", iFrameTime);
        
    }

    public virtual void Increase(int amount)
    {
        //Checking if HealthPoints not depassing MaxHealthPoints
        if (!(maxHealthPoints <= HealthPoints))
        {
            HealthPoints += amount;
        }
        else if ( HealthPoints+amount > maxHealthPoints)
        {
            HealthPoints += maxHealthPoints;
        }


    }

    public virtual void IncreaseMaxHealth(int amount)
    {
        maxHealthPoints += amount;
        HealthPoints = maxHealthPoints;
    }


}
