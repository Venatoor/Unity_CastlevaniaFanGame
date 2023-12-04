using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeArmorBattleSystem : BattleSystem
{

    public Transform axePrefab;
    public Transform axeThrowPosition;
    public Transform axeThrowDestination;
    public float axeDurationTime;
    public float axeMovementDuration;
    public float axeStopTime;

    public float axeSpeed;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        attackDurationTime = axeMovementDuration;
    }

    public override void Attack()
    {
        if (!hasAttacked)
        {

            hasAttacked = true;
            Transform spawnable = Instantiate(axePrefab, axeThrowPosition.position, transform.root.GetChild(0).rotation);
            spawnable.gameObject.AddComponent<AxeArmorAxe>();
            spawnable.GetComponent<AxeArmorAxe>().SetAxeDestination(axeThrowDestination);
            spawnable.GetComponent<AxeArmorAxe>().SetAxeSpeed(axeSpeed);
            spawnable.gameObject.SetActive(true);
            Debug.Log(transform.root.GetChild(0).rotation.y);
            spawnable.gameObject.AddComponent<ObjectDestroyer>();
            spawnable.GetComponent<ObjectDestroyer>().secondsToDestroy = axeDurationTime;

            StartCoroutine(WaitTilAttackFinished(attackDurationTime));
            StartCoroutine(AbilityCooldownReset());

        }
    
    


    }
}
