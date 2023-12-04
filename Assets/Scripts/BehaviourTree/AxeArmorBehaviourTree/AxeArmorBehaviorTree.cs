using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeArmorBehaviorTree : Tree
{

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override Node SetupTree()
    {

        Node root = new Selector(new List<Node> {
            new Sequence(new List<Node>
            {
                new EnemyHasAttacked(this, battleSystem),
                new EnemyRetreat(this)
            }),

            new Sequence(new List<Node>
            {
                new EnemyIsInAttackRange(this),
                new EnemyAttack(this, battleSystem)
            }),

            new Sequence(new List<Node>
            {
                new EnemyIsInFOVRange(this, transform),
                new EnemyChase(this)
            }),
        });
        return root;
    }

}
