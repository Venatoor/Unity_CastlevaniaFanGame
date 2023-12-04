using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour, IDamageable
{
    private Health destructibleHealth;

    private void Start()
    {
        destructibleHealth = GetComponent<Health>();
    }

    // THE HEALTH OF THE DESTRUCTIBLE SHOULD BE SPECIFIED in editor 

    public void  TakeHit(int damage, Affinities affinity)
    {
        destructibleHealth.Reduce(damage);
    }
}
