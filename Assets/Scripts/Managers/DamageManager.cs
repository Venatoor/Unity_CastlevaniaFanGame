using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{

    private static DamageManager instance;

    public static DamageManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("DamageManager");
                obj.AddComponent<DamageManager>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int ManageEnemyDamage(int damage, Affinities affinity, Enemy enemy)
    {
        int finalDamage;
        if ( enemy.GetResistances().Contains(affinity) )
        {
            finalDamage = damage / 2; 
        }
        else
        {
            finalDamage = (int)(damage * 1.5f);
        }
        return finalDamage;
    }

    public void ManageCharacterDamage()
    {

    }

    
}
