using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Finite State Machine/Condition/AttackSuccesful")]
public class AttackSuccesful : Condition
{
    public override bool Test(FiniteStateMachine fsm)
    {
        Debug.Log("attack succesful");
        return true;
    }
}
