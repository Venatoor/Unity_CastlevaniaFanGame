using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public ChaseState chaseState;
    public bool playerIsBeingSeen;
    public FieldOfView FoV;
    protected Animator anim;

    private void Awake()
    {
        anim = gameObject.GetComponentInParent<Animator>();
    }

    public override State RunCurrentState()
    {
        CheckPlayer();
        if (playerIsBeingSeen)
        {
            anim.SetBool("SkeletonIsIdle", false);
            anim.SetBool("SkeletonIsMoving", true);
            return chaseState;
        }
        else
        {
            
            return this;
        }

    }

    public void CheckPlayer()
    {
        if (FoV.canSeePlayer)
        {
            playerIsBeingSeen = true;
        }
        else
        {
            playerIsBeingSeen = false;
        }
    }
}
