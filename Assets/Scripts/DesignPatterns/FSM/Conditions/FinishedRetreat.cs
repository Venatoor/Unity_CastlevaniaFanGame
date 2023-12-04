using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Condition/FinishedRetreat")]
public class FinishedRetreat : Condition
{
    public override bool Test(FiniteStateMachine fsm)
    {
        if ( fsm.fov.timeToRetreat < 2)
        {
            fsm.fov.timeToRetreat += Time.deltaTime;
            return false;
        }
        else
        {
            fsm.fov.timeToRetreat = 0;
            return true;
        }
    }

}
