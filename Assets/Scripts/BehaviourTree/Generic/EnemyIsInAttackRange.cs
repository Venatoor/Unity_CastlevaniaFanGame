using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIsInAttackRange : Node
{
    private Tree behaviourTree;
    public EnemyIsInAttackRange(Tree tree)
    {
        behaviourTree = tree;
    }

    public override NodeState Evaluate()
    {
        bool playerDetection = behaviourTree.fov.DetectingPlayerRange();
        if (playerDetection)
        {
            behaviourTree.DesactivateSteerings();
            state = NodeState.SUCCESS;
            return state;
        }
        state = NodeState.FAILURE;
        return state;
    }
}
