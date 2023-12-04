using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public AttackState attackState;
    public bool isInRangeWithPlayer;
    public IdleState idleState;

    [Header("Chase Functionality Attributes")]
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected GameObject target;
    protected Rigidbody2D rb;
    protected Character character;
    protected Vector2 moveDirection;
    protected Vector2 destination;
    protected Vector2 retreatDestination;
    [SerializeField]
    [Range(0, 100)]
    protected float distanceOfSeparation;
    [SerializeField]
    [Range(0, 100)]
    protected float distanceOfRetreat;
    [SerializeField]
    protected FieldOfView FoV;
    [SerializeField]
    protected Enemy thisEnemy;
    public GameObject returnSpot;
    [SerializeField]
    protected float targetSpot;
    public bool hasAttacked;
    protected Vector2 facingLeft;
    protected Vector2 facingRight;
    protected Animator anim;
    public bool isDetectingPlayer;
    [SerializeField]
    protected GameObject concernedParent;

    private void Awake()
    {
        anim = gameObject.GetComponentInParent<Animator>();
        target = FindObjectOfType<Character>().gameObject;
        character = target.GetComponent<Character>();
        rb = gameObject.GetComponentInParent<Rigidbody2D>();
        concernedParent = GetComponentInParent<Enemy>().gameObject;

        facingLeft = new Vector2(concernedParent.transform.localScale.x, concernedParent.transform.localScale.y);
        facingRight = new Vector2(-concernedParent.transform.localScale.x, concernedParent.transform.localScale.y);
        

    }
    public override State RunCurrentState()
    {
        if (FoV.canSeePlayer)
        {
            idleState.playerIsBeingSeen = true;
            if (!hasAttacked)
            {
                if (true)//thisEnemy.fov.DetectingPlayer())
                {
                    isInRangeWithPlayer = true;
                    anim.SetBool("SkeletonIsMoving", false);
                    anim.SetBool("SkeletonIsAttacking", true);
                    StartCoroutine(FinishedAttack());
                    StartCoroutine(BoneIsThrowed());
                    return attackState;

                }
                else
                {
                    isInRangeWithPlayer = false;
                    
                    ChasePreparations();
                    BeginChaseSkeleton();
                    
                    return this;
                }
            }
            else
            {
                anim.SetBool("SkeletonIsAttacking", false);
                anim.SetBool("SkeletonIsMoving", true);
                RetreatPreparations();
                BeginRetreatSkeleton();
                return this;
            }
        }
        else
        {
            idleState.playerIsBeingSeen = false;
            anim.SetBool("SkeletonIsMoving", false);
            anim.SetBool("SkeletonIsIdle", true);
            return idleState;
        }
        
        
    }

    protected virtual void ChasePreparations()
    {
        Vector2 direction = (target.transform.position - transform.position).normalized;
        if (target.transform.position.x < transform.position.x)
        {
            concernedParent.transform.localScale = facingLeft;
            destination = new Vector2((target.transform.position.x + distanceOfSeparation) - transform.position.x, target.transform.position.y - transform.position.y).normalized;
        }
        else if (target.transform.position.x > transform.position.x)
        {
            concernedParent.transform.localScale = facingRight;
            destination = new Vector2((target.transform.position.x - distanceOfSeparation) - transform.position.x, target.transform.position.y - transform.position.y).normalized;
        }
        moveDirection = destination;
    }

    protected virtual void BeginChaseSkeleton()
    {
        rb.velocity = new Vector2(destination.x * speed , rb.velocity.y);
    }


    protected virtual void RetreatPreparations()
    {
        if ( target.transform.position.x < transform.position.x)
        {
            concernedParent.transform.localScale = facingLeft;
            retreatDestination = new Vector2((target.transform.position.x + distanceOfRetreat) - transform.position.x, target.transform.position.y - transform.position.y).normalized;
        }
        else if (target.transform.position.x > transform.position.x)
        {
            concernedParent.transform.localScale = facingRight;
            retreatDestination = new Vector2((target.transform.position.x - distanceOfRetreat) - transform.position.x, target.transform.position.y - transform.position.y).normalized;
        }
    }

    protected virtual void BeginRetreatSkeleton()
    {
        rb.velocity = new Vector2(retreatDestination.x * speed , rb.velocity.y);
    }


    protected virtual IEnumerator FinishedAttack() {

        yield return new WaitForSeconds(3f);
        hasAttacked = false;
        
    }

    protected virtual IEnumerator BoneIsThrowed()
    {

        yield return new WaitForSeconds(1.3f);
        attackState.boneLaunched = false;

    }


}
