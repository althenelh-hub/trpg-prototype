using UnityEngine;

public class MassSkill : Skill
{
    public MassSkill(int _radius, SkillEffects[] _effects, string name, WeaponType wType, SkillDirection direction)
        : base(_radius, _effects, name, wType, direction)
    {
        shapeName = ShapeName.Rhombus;
    }
}
