using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IDataPersistance
{
    public MeleeWeapons meleeWeapon;

    private bool canAttack;
    [SerializeField]
    protected Transform attackPoint;
    [SerializeField]
    protected LayerMask enemyLayers;
    [SerializeField]
    protected float attackRange = 0.5f;

    protected Animator anim;
    protected string weaponAnimName;

    public int damage;
    protected Enemy damagedEnemy;
    protected EnemyHealth enemyHealthToDamage;

    protected Animator attackanim;
    // Start is called before the first frame update
    void Start()
    {
        attackanim = attackPoint.GetComponent<Animator>();
        canAttack = true;
        anim = GetComponent<Animator>();
        weaponAnimName = meleeWeapon.weaponAnimName;
        if ( damage == 0) // For Data Scripts
        {
            damage = meleeWeapon.damage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    protected virtual void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && canAttack)
        {
            canAttack = false;
            attackanim.SetBool(weaponAnimName, true);
            anim.SetBool("IsAttacking", true);
            StartCoroutine(FinishedAttack());
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    damagedEnemy = enemy.GetComponent<Enemy>();
                    enemyHealthToDamage = enemy.GetComponent<EnemyHealth>();
                    enemyHealthToDamage.Reduce(damage);

                }
            }
        }
    }

    protected virtual IEnumerator FinishedAttack()
    {
        yield return new WaitForSeconds(0.02f);
        attackanim.SetBool(weaponAnimName, false);
        yield return new WaitForSeconds(0.29f);
        anim.SetBool("IsAttacking", false);
        yield return new WaitForSeconds(0.02f);
        canAttack = true;

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void IDataPersistance.LoadData(GameData data)
    {
        damage = data.playerDamage;
    }

    void IDataPersistance.SaveData(ref GameData data)
    {
        data.playerDamage = damage;
    }

    public void IncreaseWeaponDamage()
    {
        damage += 20;
    }
}

//TODO : For now in this we are just using the scriptable object's properties, in order to switch between scriptable objects
// it is possible to add in the equipment UI the possibility to read from the ui and take it to here
