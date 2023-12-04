using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashUnlock : Managers
{
    protected Jump dash;
    protected GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = FindObjectOfType<Character>().gameObject;
            dash = player.GetComponent<Jump>();
            dash.dashUnlocked = true;
            Destroy(gameObject);

        }
    }
}

