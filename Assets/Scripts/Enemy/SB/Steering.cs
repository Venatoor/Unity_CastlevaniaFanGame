using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Steering : MonoBehaviour
{

    public bool allowSteering;
    public abstract SteeringData GetSteering(SteeringBehaviorBase steeringBase); 

    public void ActivateSteering()
    {
        allowSteering = true;
    }

    public void DesactivateSteering()
    {
        allowSteering = false;
    }
}
