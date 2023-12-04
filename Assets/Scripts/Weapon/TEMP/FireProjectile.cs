using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : Managers
{
    // Start is called before the first frame update
    protected GameObject launchedFireball;

    protected bool canLaunchProjectile = true;
    [SerializeField]
    protected float projectileSpeed;
    
    [HideInInspector]
    public bool fired;

    // Update is called once per frame
    protected virtual bool LaunchFireball()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && canLaunchProjectile)
        {
            canLaunchProjectile = false;
            return true;
        }
        return false;
    }

    private void Update()
    {
        FireballLaunched();
    }

    protected virtual void FireballLaunched()
    {
        if (LaunchFireball())
        {
            character.anim.SetBool("IsAttacking", true);
            StartCoroutine(EnableShooting());
            StartCoroutine(FinishedAttack());
            Invoke("FireballMovement", 0.2f);

        }
    }

    protected virtual void FireballMovement()
    {
        GameObject launchedFireball = ObjectPooler.Instance.SpawnFromPool("Fireball", transform.position, Quaternion.identity);
        if (character.isFacingLeft)
        {
            launchedFireball.transform.localScale = new Vector2(-launchedFireball.transform.localScale.x, launchedFireball.transform.localScale.y);
            launchedFireball.GetComponent<Rigidbody2D>().velocity = (-transform.right) * projectileSpeed;

        }
        else
        {
            launchedFireball.transform.localScale = new Vector2(launchedFireball.transform.localScale.x, launchedFireball.transform.localScale.y);
            launchedFireball.GetComponent<Rigidbody2D>().velocity = (transform.right) * projectileSpeed;
        }
    }


    protected virtual IEnumerator FinishedAttack()
    {
        yield return new WaitForSeconds(0.29f);
        character.anim.SetBool("IsAttacking", false);    
    }

    protected virtual IEnumerator EnableShooting()
    {
        yield return new WaitForSeconds(0.5f);
        canLaunchProjectile = true;
    }




}
