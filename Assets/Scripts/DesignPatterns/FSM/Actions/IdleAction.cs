using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Idle")]
public class IdleAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        Debug.Log("IDLE ACTION");
    }

}
