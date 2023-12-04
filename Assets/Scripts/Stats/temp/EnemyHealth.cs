using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : Health
{
    public GameObject damageDone;
    public Transform damageShow;
    protected ExperienceT exp;
    [SerializeField]
    protected int experienceGiven;
    [SerializeField]
    protected GameObject deathEffect;
    // Start is called before the first frame update
    protected override void Initialization()
    {
        base.Initialization();
    }

    // Main Enemy Health functionalities and methods
    public override void Reduce(int amount)
    {
        base.Reduce(amount);
        // The text should be specified in its own UI Class
        GameObject textDamage = Instantiate(damageDone, damageShow.transform.position, Quaternion.identity);
        textDamage.GetComponent<TextMeshPro>().SetText(amount.ToString());
        // Here ends temp code

        // The death of an ennemy should be specified in its own class or method inside enemy
        /*
        if ( HealthPoints <= 0 )
        {
            HealthPoints = 0;
            gameObject.SetActive(false);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            exp = player.GetComponent<Experience>();
            exp.GiveExperience(experienceGiven);
        }
        // Here ends temp code 
        */
    }

    public override void Increase(int amount)
    {
        base.Increase(amount);
    }

    public override void IncreaseMaxHealth(int amount)
    {
        base.IncreaseMaxHealth(amount);
    }



    //This should be added to a renderer

    /*
    protected virtual IEnumerator Damaged()
    {
        GetComponent<SpriteRenderer>().material = alteredMaterial;
        yield return new WaitForSeconds(0.3f);
        GetComponent<SpriteRenderer>().material = originalMaterial;
    }
    */
}
