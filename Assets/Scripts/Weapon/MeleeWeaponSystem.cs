using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponSystem : MonoBehaviour
{
    //TEMP
    public Transform temp;
    public float tempValue;
    //ENDTEMP
    public Character character;
    public MeleeWeaponBase equippedWeapon;
    public Animator anim;

    [SerializeField]
    private EquipableItem weapon;

    [SerializeField]
    private InventorySO inventoryData;

    // Start is called before the first frame update
    public void Start()
    {
        character = FindObjectOfType<Character>().GetComponent<Character>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Keypad1) && character.canAttack )
        {
            anim.SetBool(equippedWeapon.weaponName, true);
            character.anim.SetBool("IsAttacking", true); // NOT AT THE ADEQUATE PLACE TBH
            equippedWeapon.UnsheathWeapon();
            StartCoroutine(SheathWeapon());
        }
    }

    public IEnumerator SheathWeapon()
    {
        yield return new WaitForSeconds(equippedWeapon.attackDuration);
        anim.SetBool(equippedWeapon.weaponName, false);
        yield return new WaitForSeconds(0.29f);
        character.anim.SetBool("IsAttacking", false); // VERY BAD CODE HERE NEED TO REFACTOR WHEN HAVING THE CAPACITIES
        yield return new WaitForSeconds(0.03f);
        character.canAttack = true; 
    }

    //FOR TESTING ONLY

    private void OnDrawGizmos()
    {
        if (temp == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(temp.position, tempValue);
    }

    public void SetWeapon(EquipableItem weaponItemSO)
    {
        if (weapon != null)
        {
            inventoryData.AddItem(weapon, 1);
        }

        this.weapon = weaponItemSO;
    }

}
