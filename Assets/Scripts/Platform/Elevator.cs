using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : Platform
{
    [SerializeField]
    private Transform PositionA;

    [SerializeField]
    private Transform PositionB;

    private Vector2 currentPosition;

    private Vector2 targetedPosition;

    private Transform temp;

    private Collider2D col;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float delayTime;

    private bool isMoving =  false;

    private Rigidbody2D rb;

    private float distance;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if ( !isMoving )
        {
            isMoving = true;
            Invoke("ActivateElevator", CalculateTime(speed, distance) + delayTime );
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        base.OnCollisionExit2D(collision);
    }

    private void Start()
    {
        temp = null;
        isMoving = false;
        currentPosition = PositionA.position;
        targetedPosition = PositionB.position;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        distance = Vector2.Distance(currentPosition, targetedPosition);
    }

    private void Update()
    {

    }
    private void FixedUpdate()
    {
        if ( isMoving)
        OnTouch(transform.position, targetedPosition);
    }
    //TO ADD TO AN ALGORITHM CLASS
    private void Permute()
    {
        temp = PositionA;
        PositionA = PositionB;
        PositionB = temp;
        currentPosition = PositionA.position;
        targetedPosition = PositionB.position;
    }


    private void OnTouch(Vector2 currentPosition, Vector2 targetedPosition)
    {

        
        rb.MovePosition(Vector2.MoveTowards(currentPosition, targetedPosition, speed * Time.deltaTime)) ;

    }


    

    private float CalculateTime(float velocity, float distance)
    {
        return distance / velocity;
    }

    private void ActivateElevator()
    {
        isMoving = false;
        Permute();
    }
}
