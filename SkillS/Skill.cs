using UnityEditor.Experimental.GraphView;
using UnityEngine;
public abstract class Skill
{
    public int radius = 1;
    public SkillEffects[] effects;
    public ShapeName shapeName;
    public WeaponType weaponType;
    public SkillDirection direction;
    public string name;
    public Skill(int _radius, SkillEffects[] _effects, string name)
    {
        effects = _effects;
        radius = _radius;
        this.name = name;
    }
    public Skill(int _radius, SkillEffects[] _effects, string name, WeaponType wType, SkillDirection direction)
    {
        effects = _effects;
        radius = _radius;
        this.name = name;
        weaponType = wType;
        this.direction = direction;
    }
    public void activate(Unit initiator, Unit target, Weapon weapon)
    {
        foreach(SkillEffects effect in effects)
        {
            effect.affect(initiator, target, 
                weapon.getModifier(weaponType), direction);
        }
        
    }
    public void takeResources(Unit performer)
    {
        Stats stats = performer.GetComponent<Stats>();
        stats.stamina.decrease(20);
        stats.balance.decrease(10);
    }
}
