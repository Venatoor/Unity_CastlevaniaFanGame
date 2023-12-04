using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeWeaponBase : EquipableItem
{
    // Perhaps there is abetter way to protect the fields using getters and setters
    public int weaponDamage;
    public string weaponName; //For animation purposes
    public string weaponType;
    public string weaponElement;
    public float attackDuration;

    public abstract void UnsheathWeapon();
}
