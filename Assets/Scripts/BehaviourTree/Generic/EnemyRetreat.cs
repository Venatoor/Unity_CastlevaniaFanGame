using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRetreat : Node
{
    Tree behaviourTree;
    public EnemyRetreat(Tree tree)
    {
        behaviourTree = tree;
    }

    public override NodeState Evaluate()
    {
        Steering[] concernedSteerings = behaviourTree.GetSteerings();
        foreach (Steering steering in concernedSteerings)
        {
            if (steering.GetType().ToString() == "RetreatBehavior")
            {
                steering.ActivateSteering();
            }
        }

        state = NodeState.RUNNING;
        return state;
    }
}
