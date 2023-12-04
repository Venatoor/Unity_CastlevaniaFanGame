using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{

    [SerializeField]
    protected int healthToGive;
    protected GameObject player;
    protected Character character;
    protected PlayerHealth playerHealth;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = FindObjectOfType<Character>().gameObject;
            character = player.GetComponent<Character>();
            playerHealth = player.GetComponent<PlayerHealth>();

            if (!(playerHealth.currentHealth.Value == playerHealth.maxHealthPoints))
            {
                playerHealth.currentHealth.Value += healthToGive;
            }

            Destroy(gameObject);
        }

    }
}
