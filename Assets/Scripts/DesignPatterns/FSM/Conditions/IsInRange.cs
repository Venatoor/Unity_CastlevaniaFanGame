using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Condition/IsInRange")]
public class IsInRange : Condition
{
    public bool negation;
    public override bool Test(FiniteStateMachine fsm)
    {
        if ( fsm.fov.DetectingPlayerRange())
        {
            if ( negation)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            if ( negation)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
