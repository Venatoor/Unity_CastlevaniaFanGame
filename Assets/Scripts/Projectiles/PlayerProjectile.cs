using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    [SerializeField]
    private Transform root;

    private Vector2 direction;

    public Transform attachement;
    public string attachmentName;

    private void Start()
    {
        attachement = GameObject.Find(attachmentName).transform;
        root = attachement.transform.root.GetChild(0);
        SetProjectileDirection();
    }

    private void FixedUpdate()
    {
        if ( !isLocked)
        {
            StartCoroutine(ProjectileOnContact());
        }
    }

    /*protected override IEnumerator ProjectileOnContact()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, projectileRadius);

        foreach (Collider2D hit in hits)
        {
            IDamageable damageableObject = hit.GetComponent<IDamageable>();

            if (damageableObject != null && !hit.gameObject.CompareTag("Player") )
            {
                damageableObject.TakeHit(projectileDamage);
                Debug.Log("damaged");
            }
        }
        yield return null;
    }
    */

    protected override IEnumerator ProjectileOnContact()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward * 4 , projectileRadius, layerMask );
        if ( hit.collider != null && hit.collider.GetComponent<IDamageable>() != null )
        {
            IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
            if (damageableObject != null)
            {
                // THIS IS VERY TEMP FOR AFFINITIES 
                damageableObject.TakeHit(projectileDamage, Affinities.Physical);
                Debug.Log("SUCCESFUL");
                isLocked = true;
            }
        }
        

        yield return null;
    }

    public Vector2 SetProjectileDirection()
    {
        if ( root.rotation.y == 0 )
        {
            return new Vector2(1, 0);
            Debug.Log(root.rotation.y);
        }
        else if ( root.rotation.y != 0)
        {
            return new Vector2(-1, 0);
            Debug.Log(root.rotation.y);
        }
        return Vector2.zero;
    }


}
