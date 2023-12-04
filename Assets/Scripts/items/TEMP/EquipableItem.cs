using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableItem : ItemSO, IDestroyableItem, IItemAction
{

    public string ActionName => "Equip";

        [field: SerializeField]
        public AudioClip actionSFX { get; private set; }

        public bool PerformAction(GameObject character)
        {
            MeleeWeaponSystem weaponSystem = character.GetComponent<MeleeWeaponSystem>();
            if (weaponSystem != null)
            {
                weaponSystem.SetWeapon(this);
                return true;
            }
            return false;
        }


}
