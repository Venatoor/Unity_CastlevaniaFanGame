using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
    [SerializeField]
    protected LayerMask enemyLayer;
    [SerializeField]
    protected int damageToDo;
    protected EnemyHealth damagedEnemy;
    [SerializeField]
    protected float projectileLifeTime;
    // Start is called before the first frame update
    protected virtual void FixedUpdate()
    {
        DamageToDo();
        CheckLifeTime();
    }

    protected virtual void DamageToDo()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 1.7f, enemyLayer);
        foreach ( Collider2D enemy in hitEnemies)
        {
            if ( enemy.CompareTag("Enemy"))
            {
                damagedEnemy = enemy.GetComponent<EnemyHealth>();
                damagedEnemy.Reduce(damageToDo);
                DestroyProjectile();

            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }
    
    protected virtual void DestroyProjectile()
    {
        gameObject.SetActive(false);
    }

    protected virtual void CheckLifeTime()
    {
        if ( projectileLifeTime > 0 )
        {
            projectileLifeTime -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
