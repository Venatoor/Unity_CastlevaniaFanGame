using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NonWeaponEquipable : Equipable
{
    public EquipmentType equipmentType;

    public abstract override void OnEquip();

    public enum EquipmentType
    {
        CHEST, HEAD, RING, BACK, TALISMAN, FEET, 
    }
}
