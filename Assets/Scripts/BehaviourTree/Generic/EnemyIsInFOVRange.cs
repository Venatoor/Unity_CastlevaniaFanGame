using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIsInFOVRange : Node
{
    private Transform _transform;
    private Tree behaviourTree;
    // Start is called before the first frame update
    public EnemyIsInFOVRange(Tree tree, Transform transform)
    {
        behaviourTree = tree;
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        bool playerDetection = behaviourTree.fov.DetectPlayer();
        if ( playerDetection )
        {
            state = NodeState.SUCCESS;
            return state;
        }
        state = NodeState.FAILURE;
        return state;

    }
}
