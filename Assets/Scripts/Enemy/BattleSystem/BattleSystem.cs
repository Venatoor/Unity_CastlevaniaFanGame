using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleSystem : MonoBehaviour
{


    public bool hasAttacked;

    public bool IsAttackFinished;

    public float attackDurationTime;

    public float abilityCooldown;
    public bool isAbilityUsed;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        IsAttackFinished = false;
        isAbilityUsed = false;
        hasAttacked = false;
    }

    protected IEnumerator WaitTilAttackFinished(float attackFinishTime)
    {
        yield return new WaitForSeconds(attackFinishTime);
        isAbilityUsed = true;
    }

    protected IEnumerator AbilityCooldownReset()
    {
        yield return new WaitForSeconds(abilityCooldown);
        isAbilityUsed = false;
        hasAttacked = false;
    }



    public bool GetAbilityCurrentState()
    {
        return isAbilityUsed;
    }


    public abstract void Attack();
}
