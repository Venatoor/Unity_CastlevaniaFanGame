using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : Node
{
    Tree behaviourTree;
    public EnemyChase(Tree tree)
    {
        behaviourTree = tree;
    }

    public override NodeState Evaluate()
    {
        Steering[] concernedSteerings = behaviourTree.GetSteerings();
        foreach ( Steering steering in concernedSteerings ) {
            if ( steering.GetType().ToString() == "ArrivalBehavior")
            {
                steering.ActivateSteering();
            }
        }

        state = NodeState.RUNNING;
        return state;
    }
}
