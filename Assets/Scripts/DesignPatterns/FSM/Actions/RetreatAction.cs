using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Retreat")]
public class RetreatAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        concernedSteerings = fsm.GetSteerings();
        foreach (Steering steering in concernedSteerings)
        {
            if (steering.GetType().ToString() == "RetreatBehavior")
            {
                Debug.Log("RETREAT ACTION");
                steering.ActivateSteering();
            }
        }
    }
}
