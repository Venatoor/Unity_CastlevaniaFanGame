using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform rotationPoint;

    public float angularSpeed, rotationRadius;

    private float posX;
    private float posY;
    [SerializeField]
    private float angle = 0;
    private void FixedUpdate()
    {
        CircularMovement();
    }

    private void CircularMovement()
    {
        posX = rotationPoint.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationPoint.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;

        if ( angle >= 360 )
        {
            angle = 0;
        }
    }


}
