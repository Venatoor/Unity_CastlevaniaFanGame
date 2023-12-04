using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/State")]
public class StateT : ScriptableObject
{
    [SerializeField]
    private Action entryAction;
    [SerializeField]
    private Action exitAction;
    [SerializeField]
    private Action[] actions;
    [SerializeField]
    private Transition[] transitions;
    [SerializeField]
    private Steering[] concernedSteerings;


    public Action GetEntryAction()
    {
        return entryAction;
    }

    public Action GetExitAction()
    {
        return exitAction;
    }

    public Action[] GetActions()
    {
        return actions;
    }

    public Transition[] GetTransitions()
    {
        return transitions;
    }

}
