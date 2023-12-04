using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJUnlock : Managers
{
    protected Jump jump;
    protected GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = FindObjectOfType<Character>().gameObject;
            jump = player.GetComponent<Jump>();
            jump.doubleJumpUnlocked = true;
            Destroy(gameObject);

        }
    }
}
