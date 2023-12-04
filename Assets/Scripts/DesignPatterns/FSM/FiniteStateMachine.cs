using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    public StateT initialState;
    private StateT currentState;

    //NEED TO CREATE DIFFERENT STATE MACHINES DEPENDING IF USABLE FOR ENEMIES OR CHARACTERS*
    [HideInInspector]
    public FieldOfView fov;
    public Steering[] steerings;
    // Start is called before the first frame update
    void Start()
    {
        currentState = initialState;
        fov = GetComponent<FieldOfView>();
        steerings = GetComponents<Steering>();

    }

    // Update is called once per frame
    void Update()
    {
        Transition triggeredTransition = null;
        foreach (Transition t in currentState.GetTransitions())
        {
            if (t.IsTriggered(this))
            {
                triggeredTransition = t;
                break;
            }
        }
        List<Action> actions = new List<Action>();
        if (triggeredTransition)
        {
            DesactivateSteerings();
            StateT targetState = triggeredTransition.GetTargetState();
            actions.Add(currentState.GetExitAction());
            actions.Add(triggeredTransition.GetAction());
            actions.Add(targetState.GetEntryAction());
            currentState = targetState;
        }
        else
        {
            foreach (Action a in currentState.GetActions())
            {
                actions.Add(a);
            }
        }
        DoActions(actions);

    }

    void DoActions(List<Action> actions)
    {
        foreach (Action a in actions)
        {
            if (a != null)
            {
                a.Act(this);
            }
        }
    }

    void DesactivateSteerings()
    {
        foreach ( Steering steering in steerings)
        {
            steering.DesactivateSteering();
        }
    }

    public Steering[] GetSteerings()
    {
        return steerings;
    }
}
