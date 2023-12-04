using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoWayPlatform : Platform
{

    private Collider2D col;
    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        base.OnCollisionExit2D(collision);
    }

    private void DesactivateCollider()
    {
        
    }


    private void CheckPlayer()
    {

    }



    //On input desactivate collider
    //On jump from under platform use raycasts

}
