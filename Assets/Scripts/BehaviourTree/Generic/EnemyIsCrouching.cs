using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIsCrouching : Node
{
    private Tree behaviorTree;
    private Character character;

    public EnemyIsCrouching(Tree behaviorTree, Character character)
    {
        this.behaviorTree = behaviorTree;
        this.character = character;
    }
    // Start is called before the first frame update
    public override NodeState Evaluate()
    {
        return base.Evaluate();
        if ( character.currentState == CharacterState.CROUCHING)
        {
            state = NodeState.SUCCESS;
            return state;
        }
        state = NodeState.FAILURE;
        return state;
    }
}
