using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Abilities, IDataPersistance
{
    protected float jumpVelocity;
    [SerializeField]
    protected float holdTime;
    [SerializeField]
    protected float maxJumpSpeed;
    [SerializeField]
    protected float maxFallSpeed;
    [SerializeField]
    protected float acceptedFallSpeed;
    [SerializeField]
    protected LayerMask jumpLayer;
    [SerializeField]
    protected float distanceToCollider;
    [SerializeField]
    protected bool limitAirJumps;
    [SerializeField]
    protected float maxJumps;
    [SerializeField]
    protected float holdForce;

    private float jumpHeight;

    private float gravityScale;
    private float fallingGravityScale;

    [SerializeField]
    protected GameObject jumpUnlockObject;

    [SerializeField]
    protected GameObject dashUnlockObject;

    private float jumpsLeft;
    private float jumpsDone;
    private float jumpCountDown;
    // Start is called before the first frame update

    // Update is called once per frame

    protected override void Initialization()
    {
        base.Initialization();
        jumpsLeft = maxJumps;
         
        jumpCountDown = holdTime;

        gravityScale = 1f;
        fallingGravityScale = gravityScale * 3f;

        jumpHeight = col.size.y * 2f;
        jumpVelocity = Mathf.Sqrt(-2 * jumpHeight * Physics2D.gravity.y * rb.gravityScale) * 1.5f;
        holdTime = jumpHeight / jumpVelocity;
        Debug.Log(holdTime);
    }
    protected virtual void Update()
    {
        JumpPressed();
        JumpHeld();

        JumpMode();
        HeightChecker();
    }

    protected virtual void HeightChecker()
    {
    }

    protected virtual bool JumpPressed()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!character.isGrounded && jumpsLeft ==  maxJumps )
            {
                character.currentState = CharacterState.IDLE;
                return false;
            }
            /*
            if ( limitAirJumps && character.Falling(acceptedFallSpeed) )
            {
                character.isJumping = false;
                return false;
            }
            */
            jumpsLeft--;
            jumpsDone++;
            if (jumpsLeft > 0 )
            {
                jumpCountDown = holdTime;
                character.currentState = CharacterState.JUMPING;
            }
            if ( jumpsLeft == 0 )
            {
                if ( doubleJumpUnlocked)
                {
                    jumpCountDown = holdTime;
                    character.currentState = CharacterState.JUMPING;
                }
            }
            return true;

        }
        else
        {
            return false;
        }
    }

    protected virtual bool JumpHeld()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            return true;
        }
        //TEMP DOWNSPEED
        return false;
    }

    protected virtual void FixedUpdate()
    {
        IsJumping();
        GroundCheck();
    }

    protected virtual void IsJumping()
    {
        if ( character.currentState == CharacterState.JUMPING )
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);

            rb.velocity = new Vector2(0, jumpVelocity);
            AdditionalAir();
        }
        if ( rb.velocity.y > maxJumpSpeed )
        {
            rb.velocity = new Vector2(rb.velocity.x, maxJumpSpeed);
        }
    }

    protected virtual void AdditionalAir()
    {
        if ( JumpHeld())
        {
            jumpCountDown -= Time.deltaTime;
            if ( jumpCountDown <= 0)
            {
                jumpCountDown = 0;
                character.currentState = CharacterState.IDLE;

            }
            else
            {
                rb.AddForce(Vector2.up * holdForce);
            }
        }
        else
        {
            character.currentState = CharacterState.IDLE;
        }
    }
    protected virtual void GroundCheck()
    {
        if ( CollisionCheck(Vector2.down, distanceToCollider, jumpLayer) && (character.currentState != CharacterState.JUMPING))
        {
            character.isGrounded = true;
            anim.SetBool("IsGrounded", true);
            jumpsLeft = maxJumps;
        }
        
        else
        {
            character.isGrounded = false;
            anim.SetBool("IsGrounded", false);
            if (character.Falling(0) && rb.velocity.y <= maxFallSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, maxFallSpeed);
            }
        }
        
    }

    private void JumpMode()
    {
        if (character.currentState != CharacterState.DASHING    )
        {
            if (rb.velocity.y > 0)
            {
                rb.gravityScale = gravityScale;
            }
            else
            {
                rb.gravityScale = fallingGravityScale;
            }
        }
    }

    //TO ADD INTERUPTIONS

    //REFACTORING
    //OTHER TIPS AND TRICKS


    void IDataPersistance.LoadData(GameData data)
    {
        doubleJumpUnlocked = data.playerDoubleJumpUnlock;
        if ( doubleJumpUnlocked )
        {
            jumpUnlockObject.SetActive(false);
        }

        dashUnlocked = data.playerDashUnlock;
        if (dashUnlocked)
        {
            dashUnlockObject.SetActive(false);
        }
    }

    void IDataPersistance.SaveData(ref GameData data)
    {
        data.playerDoubleJumpUnlock = doubleJumpUnlocked;

        data.playerDashUnlock = dashUnlocked;
    }


}
