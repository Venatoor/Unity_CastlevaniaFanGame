using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHasAttacked : Node
{
    private Tree behaviourTree;
    private BattleSystem battleSystem;
    // Start is called before the first frame update
    public EnemyHasAttacked( Tree behaviourTree, BattleSystem battleSystem)
    {
        this.behaviourTree = behaviourTree;
        this.battleSystem = battleSystem;
    }

    public override NodeState Evaluate()
    {
        bool isAbilityInCooldown = battleSystem.GetAbilityCurrentState();
        if ( isAbilityInCooldown )
        {
            state = NodeState.SUCCESS;
            return state;
        }
        behaviourTree.DesactivateSteerings();
        state = NodeState.FAILURE;
        return state;
    }
}
