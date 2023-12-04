using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouching : Abilities
{
    protected Vector2 originalOffset;
    protected Vector2 originalSize;
    private Vector2 crouchingOffset;
    private Vector2 crouchingSize;
    protected CapsuleCollider2D characterCollider;
    // Start is called before the first frame update
    private void Start()
    {
        Initialization();
        characterCollider = GetComponent<CapsuleCollider2D>();
        originalOffset = characterCollider.offset;
        originalSize = characterCollider.size;
        crouchingSize = new Vector2(originalSize.x, originalSize.y / 2);
        crouchingOffset = new Vector2(originalOffset.x, originalOffset.y * 2);

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void FixedUpdate()
    {
        OnCrouchInput();
        Crouch();
    }


    protected bool OnCrouchInput()
    {
        if ( Input.GetKey(KeyCode.S)) { 
            return true;

        }
        //TODO : Reset
        return false;
    }

    protected void Crouch()
    {
        if ( character.isGrounded && OnCrouchInput())
        {
            character.currentState = CharacterState.CROUCHING;
            characterCollider.offset = crouchingOffset;
            characterCollider.size = crouchingSize;
        }
        else
        {
            if ( character.currentState == CharacterState.CROUCHING )
            {
                StartCoroutine(DisableCrouching());
            }
        }
    }

    protected IEnumerator DisableCrouching()
    {
        characterCollider.offset = originalOffset;
        yield return new WaitForSeconds(.01f);
        characterCollider.size = originalSize;
        yield return new WaitForSeconds(.01f);
        character.currentState = CharacterState.IDLE;
    }

    protected void CeillingDetection()
    {

    }


}
