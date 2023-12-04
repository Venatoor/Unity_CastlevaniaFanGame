using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeHit(int damage, Affinities affinity);

    //it should be instead TakeHit(int damage, Affinities affinityType ) 
}
