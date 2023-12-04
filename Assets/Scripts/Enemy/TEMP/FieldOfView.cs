using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius = 5f;
    [Range(1, 360)] public float angle = 45f;
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;

    public float attackRange;
    public LayerMask playerLayers;
    public GameObject playerRef;
    public bool canSeePlayer;
    public float distanceToPlayer;
    public float timeToRetreat = 0;

    void Start()
    {
        playerRef = FindObjectOfType<Character>().gameObject;
        StartCoroutine(FOVCheck());
    }

    
    void Update()
    {
        
    }
    
    private IEnumerator FOVCheck()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.2f);
            DetectPlayer();
        }
    }
    public virtual bool DetectingPlayerRange()
    {
        Collider2D[] playerRange = Physics2D.OverlapCircleAll(transform.position, attackRange, playerLayers);
        foreach (Collider2D player in playerRange)
        {
            if (player != null)
            {
                return true;
            }
        }
        return false;
    }

    public virtual bool GreaterThanDistance()
    {
        if ( Vector3.Distance(transform.position,playerRef.transform.position) > distanceToPlayer )
        {
            return true;
        }
        return false;
    }

    public bool DetectPlayer()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.up, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);
                if ( !Physics2D.Raycast(transform.position,directionToTarget,distanceToTarget,obstructionLayer))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;

        }
        return false;
     
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
