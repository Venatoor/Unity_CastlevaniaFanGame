using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatBehavior : Steering
{
    [SerializeField]
    private Transform target;

    public override SteeringData GetSteering(SteeringBehaviorBase steeringBase)
    {
        
            SteeringData steering = new SteeringData();
        if (allowSteering)
        {
            steering.linear = target.transform.position - transform.position;
        steering.linear.Normalize();
        steering.linear *= -steeringBase.maxAcceleration;
        steering.angular = 0;
        return steering;
        }
        return steering;
    }
}
