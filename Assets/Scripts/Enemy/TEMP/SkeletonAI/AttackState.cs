using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public bool attackIsSuccesful;
    public bool boneLaunched;
    public ChaseState chaseState;
    [SerializeField]
    protected GameObject attackLaunchPoint;
    protected GameObject concernedParent;
    [SerializeField]
    protected GameObject parent;
    [SerializeField]
    protected GameObject gameObjectToTest;
    protected Rigidbody2D rb;


    private void Start()
    {
        rb = gameObjectToTest.GetComponent<Rigidbody2D>();
        concernedParent = GetComponentInParent<Enemy>().gameObject;
    }



    public override State RunCurrentState()
    {
        if (!boneLaunched)
        {
            boneLaunched = true;
            if (concernedParent.transform.position.x > parent.transform.position.x)
            {
                GameObject bone = ObjectPooler.Instance.SpawnFromPool("Bone", attackLaunchPoint.transform.position, Quaternion.identity);
                rb = bone.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(-1 * 480, -1 * -200));
                StartCoroutine(PauseInOrderToAttack());
                return chaseState;
            }
            else if ( concernedParent.transform.position.x < parent.transform.position.x)
            {
                GameObject bone = ObjectPooler.Instance.SpawnFromPool("Bone", attackLaunchPoint.transform.position, Quaternion.identity);
                rb = bone.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(1 * 480, -1 * -200));
                StartCoroutine(PauseInOrderToAttack());
                return chaseState;
            }
        }
        return chaseState;
        
    }



    public IEnumerator PauseInOrderToAttack()
    {
        yield return new WaitForSeconds(1f);
        chaseState.hasAttacked = true;
        
    }
}


