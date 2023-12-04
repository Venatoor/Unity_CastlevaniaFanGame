using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSteal : MonoBehaviour, ICastableAbility
{

    public float circleRadius;

    private Transform playerPivot;

    public int damage;

    public GameObject soulPrefab;

    // Soul steal increases health of player per enemy damaged 
    // Soul steal is defined by a circle of a radius 
    // if on input an enemy is touched within the radius send forth a soul into Dhampir and gain health

    private void Start()
    {
        playerPivot = FindObjectOfType<Character>().transform;
    }
    public void ExecuteAbility()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(playerPivot.position, circleRadius);

        foreach ( Collider2D hit in hits)
        {
            IDamageable damageableObject = hit.GetComponent<IDamageable>();

            if (damageableObject != null && !hit.gameObject.CompareTag("Player"))
            {
                damageableObject.TakeHit(damage, Affinities.Dark);
                Instantiate(soulPrefab, hit.transform.position, Quaternion.identity);

            }
        }
    }
}
