using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState { DASHING, CROUCHING, JUMPING, IDLE }
public class Character : MonoBehaviour, IDamageable
{
    //COMPONENTS
    protected Rigidbody2D rb;
    protected CapsuleCollider2D col;
    public Animator anim;
    private PlayerHealth characterHealth;
    //END COMPONENTS

    //ABILITIES 
    [HideInInspector]
    public bool canMove;
    [HideInInspector]
    public bool isGrounded;
    [HideInInspector]
    public bool isFacingLeft;
    [HideInInspector]
    public bool canDash;
    //END ABILITIES

    public CharacterState currentState;



    //CHARACTER COMBAT SYSTEM
    [HideInInspector]
    public bool canAttack;
    [HideInInspector]
    public bool isHit;
    [HideInInspector]
    public bool isInvincible;
    //CHARACTER COMBAT SYSTEM END

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
        characterHealth = GetComponent<PlayerHealth>();
        canMove = true;
        currentState = CharacterState.IDLE;
    }

    private void FixedUpdate()
    {
        BoundVolumeCheck();
        Flip();
    }

    private void Update()
    {

    }
    // Update is called once per frame
    protected virtual void Initialization()
    {
        isFacingLeft = false;
        isHit = false;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        canAttack = true;

    }

    protected virtual void Flip()
    {
        if ( isFacingLeft )
        {
            //transform.localScale = facingLeft;
            //rotationVector.y = 0;
            transform.rotation = Quaternion.Euler(new Vector2(0, 180));

        }
        else
        {
            //transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            //rotationVector.y = 180;
            transform.rotation = Quaternion.Euler(new Vector2(0, 0));
        }
    }

    public virtual bool Falling(float speed)
    {
        if ( !isGrounded && rb.velocity.y > speed)
        {
            return true;
        }
        return false;
    }

    protected virtual bool CollisionCheck(Vector2 direction, float distance, LayerMask collision)
    {
        RaycastHit2D[] hits = new RaycastHit2D[10];
        int numHits = col.Cast(direction, hits, distance);
        for (int i = 0; i < numHits; i++)
        {
            if ((1 << hits[i].collider.gameObject.layer & collision) != 0)
            {
                return true;
            }
        }
        return false;
    }

    public void TakeHit(int damage, Affinities affinity)
    {

        // ADD RESISTANCE CODE HERE LATER ON WHEN ADDING STAT CODE
        characterHealth.Reduce(damage);
    }

    public void BoundVolumeCheck()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, FloorManager.Instance.GetCurrentFloorBoundsMinX(), FloorManager.Instance.GetCurrentFloorBoundsMaxX())
            , (Mathf.Clamp(transform.position.y, FloorManager.Instance.GetCurrentFloorBoundsMinY(), FloorManager.Instance.GetCurrentFloorBoundsMaxY())));
    }

    public void AllowMovement()
    {
        canMove = true;
    }

    public void DisactivateMovement()
    {
        canMove = false;
    }

    public void DesactivateGravity()
    {
        rb.gravityScale = 0f;
    }

    public void ActivateGravity()
    {
        rb.gravityScale = 1.2f;
    }

    public void ActivateInvincibility()
    {
        isInvincible = true;
        //TEMP TO ADD LATER ON LOGIC
    }

    public void DesactivateInvincibility()
    {
        isInvincible = false;
    }
}
