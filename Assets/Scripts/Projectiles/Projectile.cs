using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField]
    protected int projectileDamage;
    [SerializeField]
    protected bool isDestructibleOnHit;
    [SerializeField]
    protected float projectileRadius;
    [SerializeField]
    protected bool isLocked = false;
    [SerializeField]
    protected LayerMask layerMask;
    [SerializeField]
    protected ProjectileMovement projectileMovement;

    private void Start()
    {
        projectileMovement = GetComponent<ProjectileMovement>();
    }

    protected abstract IEnumerator ProjectileOnContact();


}
