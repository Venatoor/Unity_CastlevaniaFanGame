using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Transitions")]
public class Transition : ScriptableObject
{
    [SerializeField]
    private Condition decision;
    [SerializeField]
    private Action action;
    [SerializeField]
    private StateT targetState;


    public bool IsTriggered(FiniteStateMachine fsm)
    {
        return decision.Test(fsm);
    }

    public Action GetAction()
    {
        return action;
    }

    public StateT GetTargetState()
    {
        return targetState;
    }
}
