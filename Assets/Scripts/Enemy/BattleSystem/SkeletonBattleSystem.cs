using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBattleSystem : BattleSystem
{
    public Transform bonePrefab;
    public Transform boneThrowPosition;
    public float boneDurationTime;

    //TEMP 

    public float speed;

    //END TEMP
    protected override void Start()
    {
        base.Start();
    }

    //TO CHANGE 
    public override void Attack()
    {
        if (!hasAttacked)
        {
            hasAttacked = true;
            Transform spawnable = Instantiate(bonePrefab, boneThrowPosition.position, transform.root.GetChild(0).rotation);
            spawnable.gameObject.SetActive(true);
            Debug.Log(transform.root.GetChild(0).rotation.y);
            spawnable.gameObject.AddComponent<ObjectDestroyer>();
            spawnable.GetComponent<ObjectDestroyer>().secondsToDestroy = boneDurationTime;
            //spawnable.SetParent(abilityContainer);

            if (transform.root.GetChild(0).rotation.y == -1 || transform.root.GetChild(0).rotation.y == 1)
            {

                StartCoroutine(TranslationMovement.Instance.DoTranslationX(spawnable, speed * 3, new Vector2(1, 0), 500f));

            }

            else
            StartCoroutine(TranslationMovement.Instance.DoTranslationX(spawnable, speed * 3, new Vector2(-1, 0), 500f));
            StartCoroutine(WaitTilAttackFinished(attackDurationTime));
            StartCoroutine(AbilityCooldownReset());
        }
    }



}
