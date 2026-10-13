using System.Collections.Generic;
using UnityEngine;

public class Body : MapObject
{
    public Equipment equipment;
    Weapon stuckedWeapon;
    public void SetEquipment(Equipment equip, Weapon weapon)
    {
        equipment = equip;
        stuckedWeapon = weapon;
    }
    public Weapon[] GetWeapons()
    {
        List<Weapon> weapons = new List<Weapon>();
        Weapon current = equipment.getMainWeapon();
        if (current != null) {
            weapons.Add(current);
        }
        current = equipment.getSecondaryWeapon();
        if (current != null) {
            weapons.Add(current);
        }
        if (stuckedWeapon != null) {
            weapons.Add(stuckedWeapon);
        }
        return weapons.ToArray();
    }
}
