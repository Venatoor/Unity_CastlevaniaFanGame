using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : Node
{
    private Tree behaviourTree;
    private BattleSystem battleSystem;

    public EnemyAttack(Tree behaviourTree, BattleSystem battleSystem)
    {
        this.behaviourTree = behaviourTree;
        this.battleSystem = battleSystem;
    }

    public override NodeState Evaluate()
    {
        float counter = 0f;

        battleSystem.Attack();

            state = NodeState.SUCCESS;
            return state;
        
    }


}
