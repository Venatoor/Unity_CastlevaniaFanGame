using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : Platform
{
    public float lerpDuration;
    public bool isRotating;
    public int rotationAngle;
    public float delayTime;
    public float activationTime;

    public Collider2D col;
    private void Start()
    {
        col = GetComponent<Collider2D>();
        isRotating = false;
        delayTime = lerpDuration + 0.2f;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if ( !isRotating)
        {
            StartCoroutine(OnTouch());
        }
    }

    public override void OnCollisionExit2D(Collision2D collision)
    {
    }

    public IEnumerator OnTouch()
    {
        isRotating = true;
        yield return new WaitForSeconds(activationTime);
        col.enabled = false;
        float timeElapsed = 0;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, 0, rotationAngle);
        while ( timeElapsed < lerpDuration )
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;
        col.enabled = true;
        yield return new WaitForSeconds(delayTime);
        isRotating = false;
    }


}
