using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField]
    protected LayerMask playerlayer;
    [SerializeField]
    protected int damageToDo;
    protected PlayerHealth damagedPlayer;
    [SerializeField]
    protected float projectileLifeTime;
    protected GameObject player;
    protected PlayerHealth character;
    // Start is called before the first frame update


    void Update()
    {
        Invoke("DestroyBone", 1f);
        DamageToDo();
    }

    // Update is called once per frame
    protected virtual void DamageToDo()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, 0.7f, playerlayer);
        foreach (Collider2D player in hitPlayers)
        {
            if (player.CompareTag("Player"))
            {
                damagedPlayer = player.GetComponent<PlayerHealth>();
                damagedPlayer.Reduce(damageToDo);

            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 0.7f);
    }


    public void DestroyBone()
    {
        gameObject.SetActive(false);
    }
}
