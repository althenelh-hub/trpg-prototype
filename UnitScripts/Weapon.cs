using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Weapon
{
    Dictionary<WeaponType, int> modifiers = new Dictionary<WeaponType, int>();
    int weight;
    public string name;
    public Weapon(Dictionary<WeaponType, int> _modifiers, int weight, string name)
    {
        modifiers = _modifiers;
        this.weight = weight;
        this.name = name;
    }
    public Weapon(int _weight)
    {
        weight = _weight;
    }
    public void addModier(WeaponType weaponType, int mod)
    {
        modifiers.Add(weaponType, mod);
    }
    public int getModifier(WeaponType weaponType)
    {
        if(modifiers.ContainsKey(weaponType)) { return modifiers[weaponType]; }
        else { return 0; }
    }
    public WeaponType[] getTypes()
    {
        return modifiers.Keys.ToArray();
    }
    public int getWeight()
    {
        return weight;
    }
}
