using UnityEngine;

public class PolyaxeSlashSkill : Skill
{
    public PolyaxeSlashSkill(int _radius, SkillEffects[] _effects, string name, WeaponType wType, SkillDirection direction) 
        : base(_radius, _effects, name, wType, direction)
    {
        shapeName = ShapeName.QuaterCircle;
    }
}
