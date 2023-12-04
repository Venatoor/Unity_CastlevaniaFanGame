using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Chase")]
public class ChaseAction : Action
{

    public override void Act(FiniteStateMachine fsm)
    {
        concernedSteerings = fsm.GetSteerings();
        foreach ( Steering steering in concernedSteerings)
        {
            if (steering.GetType().ToString() == "ArrivalBehavior")
            {
                Debug.Log("CHASE ACTION");
                steering.ActivateSteering();
            }
        }
    }
}
