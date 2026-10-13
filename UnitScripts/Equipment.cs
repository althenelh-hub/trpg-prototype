using UnityEngine;

public class Equipment : MonoBehaviour
{
    Weapon mainWeapon;
    Weapon secondaryWeapon;
    public Armor armor = new Armor();
    //Weapon currentWeapon;
    public WeaponType[] getWeaponTypes() 
    {
        int arrayLength = 0;
        WeaponType[] main = new WeaponType[0];
        WeaponType[] secondary = new WeaponType[0];
        if (mainWeapon != null)
        {
            main = mainWeapon.getTypes();
            arrayLength += main.Length;

        }
        if(secondaryWeapon != null)
        {
            secondary = secondaryWeapon.getTypes();
            arrayLength += secondary.Length;
        }
        WeaponType[] result = new WeaponType[arrayLength];
        int i = 0;
        foreach(WeaponType type in main)
        {
            result[i] = type;
            i++;
        }
        foreach (WeaponType type in secondary) { 
            result[i] = type;
            i++;
        }
        return result;
    }
    public Weapon getSecondaryWeapon()
    {
        return secondaryWeapon;
    }
    public Weapon getMainWeapon()
    {
        return mainWeapon;
    }
    public void setMainWeapon(Weapon weapon)
    {
        mainWeapon = weapon;
    }
    public void setSecondaryWeapon(Weapon weapon)
    {
        secondaryWeapon = weapon;
    }
    public void receiveDamage(int damage, SkillDirection direction)
    {
        if(!armor.checkArmor(direction))
        {
            Unit unit = GetComponent<Unit>();
            unit.Dead = true;
            return;
        }
        armor.receiveAttack(damage, direction);
    }
}
