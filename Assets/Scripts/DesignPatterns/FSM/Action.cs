using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class Action : ScriptableObject
{
    [SerializeField]
    public Steering[] concernedSteerings;
    public SteeringBehaviorBase steeringBehaviorBase;
    public abstract void Act(FiniteStateMachine fsm);

}
