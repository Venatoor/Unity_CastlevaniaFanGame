using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CapsuleCollider2D))]
public class Dash : Abilities
{
    [SerializeField]
    protected float dashSpeed;
    [SerializeField]
    protected float dashCooldownTime;
    [SerializeField]
    protected float dashAmountTime;
    private float dashCountdown;

    [SerializeField]
    protected SpriteRenderer SR, afterImage;
    [SerializeField]
    protected float afterImagesLifeTime, timeBetweenAfterImages;
    private float afterImageCounter;
    [SerializeField]
    protected Color afterImageColor;

    [SerializeField]
    protected float afterImageDuration;


    private float afterImageCooldown;
    // Start is called before the first frame update
    protected override void Initialization()
    {
        base.Initialization();
        character.canDash = true; // TEMP
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        DashPressed();
        DashReset();
        DashMode();
    }



    protected virtual void DashPressed()
    {
        if ( Input.GetKey(KeyCode.LeftShift) && character.canDash ) 
        {
            {

                dashCountdown = dashCooldownTime;
                afterImageCooldown = afterImageDuration;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                character.DesactivateGravity();
                Debug.Log(rb.gravityScale);
                //END TEMP
                character.DisactivateMovement(); // Perhaps better with a observer design pattern
                                                 //END TEMP

                //TEMP
                character.currentState = CharacterState.DASHING;
                StartCoroutine(FinishedDashing());
                StartCoroutine(DashEffect());
            }
        }
    }

    protected virtual void DashMode()
    {
        if ( character.currentState == CharacterState.DASHING )
        {
            if ( !character.isFacingLeft )
            {
                StartCoroutine(TranslationMovement.Instance.DoTranslationX(character.transform, dashSpeed , Vector2.right, 1f)); // TEMP
            }
            else
            {
                StartCoroutine(TranslationMovement.Instance.DoTranslationX(character.transform, dashSpeed , Vector2.left, 1f)); // TEMP
            }
        }
    }

    protected virtual void DashReset()
    {
        if ( dashCountdown > 0 )
        {
            character.canDash = false;
            dashCountdown -= Time.deltaTime;
            if (afterImageCooldown > 0)
            {
                afterImageCounter -= Time.deltaTime;
                afterImageCooldown -= Time.deltaTime;
                if (afterImageCounter <= 0.5)
                {
                    StartCoroutine(DashEffect());
                }
            }
        }
        else
        {
            character.canDash = true;

        }
    }

    protected virtual IEnumerator FinishedDashing()
    {
        yield return new WaitForSeconds(dashAmountTime);
        //TEMP
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        character.ActivateGravity();
        //END TEMP
        character.currentState = CharacterState.IDLE;
        character.AllowMovement();
        rb.velocity = new Vector2(0, rb.velocity.y);

        
    }

    protected virtual IEnumerator DashEffect()
    {

            SpriteRenderer image = Instantiate(afterImage, transform.position, transform.rotation);
            image.sprite = SR.sprite;
            image.transform.localScale = transform.localScale;
            image.color = afterImageColor;

            yield return new WaitForSeconds(afterImagesLifeTime);
            Destroy(image.gameObject);

            afterImageCounter = timeBetweenAfterImages;
    }


    //LOGIC TO ADD, DESACTIVATE COLLISION, ADD FOG SHADER, 
}
