using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivalBehavior : Steering
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float targetRadius = 1.5f;
    [SerializeField]
    private float slowRadius = 5f;

    public override SteeringData GetSteering(SteeringBehaviorBase steeringBase) {
        SteeringData steering = new SteeringData();
        if (allowSteering)
        {
            Vector3 direction = target.position - transform.position;
            float distance = direction.magnitude;

            if (distance < targetRadius)
            {
                steeringBase.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                return steering;
            }
            float targetSpeed;
            if (distance > slowRadius)
            {
                targetSpeed = steeringBase.maxAcceleration;

            }
            else
            {
                targetSpeed = steeringBase.maxAcceleration * (distance / slowRadius);
            }
            Vector3 targetVelocity = direction;
            targetVelocity.Normalize();
            targetVelocity *= targetSpeed;
            steering.linear = targetVelocity - (Vector3)steeringBase.GetComponent<Rigidbody2D>().velocity;
            if (steering.linear.magnitude > steeringBase.maxAcceleration)
            {
                steering.linear.Normalize();
                steering.linear *= steeringBase.maxAcceleration;
            }
            steering.angular = 0;
            return steering;
        }
        return steering;
    }
}
