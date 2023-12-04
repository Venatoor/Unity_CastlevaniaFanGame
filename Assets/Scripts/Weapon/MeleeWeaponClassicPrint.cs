using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MeleeWeaponClassicPrint : MeleeWeaponBase
{
    public GameObject weaponPosition;
    public float weaponBoundaries;
    public LayerMask layers;


    public override void UnsheathWeapon()
    {
        weaponPosition = FindObjectOfType<MeleeWeaponSystem>().gameObject; // an indispensable occurence due to the staticity of 
        // ScriptableObjects
        Collider2D[] hits = Physics2D.OverlapCircleAll(weaponPosition.transform.position, weaponBoundaries);
        
        foreach ( Collider2D hit in hits )
        {
            IDamageable damageableObject = hit.GetComponent<IDamageable>();
            
            if (damageableObject != null && !hit.gameObject.CompareTag("Player"))
            {
                damageableObject.TakeHit(weaponDamage, Affinities.Physical);
            }
        }
    }
}
