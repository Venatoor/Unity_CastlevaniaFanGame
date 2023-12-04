using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Condition/CanSeeEnemy")]
public class CanSeeEnemy : Condition
{
    public bool negation;
    public override bool Test(FiniteStateMachine fsm)
    {
        if ( fsm.fov.DetectPlayer())
        {
            if (negation)
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
            if (negation)
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
