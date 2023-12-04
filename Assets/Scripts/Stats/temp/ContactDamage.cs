using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    protected GameObject player;
    protected Character character;
    protected PlayerHealth playerHealth;
    protected int damage;


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Enemy"))
        {
            player = FindObjectOfType<Character>().gameObject;
            character = player.GetComponent<Character>();
            playerHealth = player.GetComponent<PlayerHealth>();
            damage = collision.GetComponent<Enemy>().damageOnContact;
            playerHealth.Reduce(damage);
        }
    }
}
