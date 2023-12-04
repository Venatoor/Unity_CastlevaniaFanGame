using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviorBase : MonoBehaviour
{
    private Rigidbody2D rb;
    private Steering[] steerings;
    public float maxAcceleration = 10f;
    public float maxAngularAcceleration = 3f;
    public float drag = 1f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        steerings = GetComponents<Steering>();
        rb.drag = drag;
    }

    private void FixedUpdate()
    {
        Vector3 acceleration = Vector3.zero;
        float rotation = 0f;
        foreach (Steering behavior in steerings)
        {
            SteeringData steering = behavior.GetSteering(this);
            acceleration += steering.linear;
            rotation += steering.angular;
        }
        if (acceleration.magnitude > maxAcceleration)
        {
            acceleration.Normalize();
            acceleration *= maxAcceleration;
        }
        rb.AddForce(acceleration);
        if (rotation != 0)
        {
            rb.rotation = Quaternion.Euler(0, rotation, 0).eulerAngles.y;
        }
    }

    public Steering[] GetSteerings()
    {
        return steerings;
    }

    public void DesactivateAllSteerings( )
    {
        foreach ( Steering steering in steerings)
        {
            steering.DesactivateSteering();
        }
    }
}
