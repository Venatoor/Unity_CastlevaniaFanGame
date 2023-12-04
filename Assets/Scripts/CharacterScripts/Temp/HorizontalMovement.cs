using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HorizontalMovement : Abilities
{

    [SerializeField]
    protected float timeTillMaxSpeed;
    [SerializeField]
    protected float MaxSpeed;
    private float runTime;
    private float currentSpeed;
    private float acceleration;
    private float horizontalInput;



    

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Initialization();
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        MovementPressed();
    }

    protected virtual bool MovementPressed()
    {
            if (Input.GetAxis("Horizontal") != 0)
            {

                return true;
            }
            else
            {
                return false;
            }
    }
    protected virtual void FixedUpdate()
    {
        Movement();
    }



    protected virtual void Movement()
    {
        if ( MovementPressed() && character.canMove )
        {
            
                horizontalInput = Input.GetAxis("Horizontal");
                acceleration = MaxSpeed / timeTillMaxSpeed;
                runTime += Time.deltaTime;
                currentSpeed = horizontalInput * acceleration * runTime;
                anim.SetBool("IsMoving", true);
                CheckDirection();
        }
        else
        {
            anim.SetBool("IsMoving", false);
            acceleration = 0;
            runTime = 0;
            currentSpeed = 0;
        }
        anim.SetFloat("CurrentSpeed", currentSpeed);
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
    }

    protected virtual void CheckDirection()
    {
        if ( currentSpeed > 0 )
        {
            if (character.isFacingLeft)
            {
                character.isFacingLeft = false;
                Flip();
            }
            if ( currentSpeed > MaxSpeed )
            {
                currentSpeed = MaxSpeed;
            }
        }
        if ( currentSpeed < 0 )
        {
            if (!character.isFacingLeft)
            {
                character.isFacingLeft = true;
                Flip();
            }
            if ( currentSpeed < -MaxSpeed )
            {
                currentSpeed = -MaxSpeed;
            }
        }
    }



}
