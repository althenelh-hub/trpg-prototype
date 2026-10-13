using UnityEngine;

public class LongRangedSkill : Skill
{
    public LongRangedSkill(int _radius, SkillEffects[] _effects, string name, WeaponType wType, SkillDirection direction)
        : base(_radius, _effects, name, wType, direction)
    {
        shapeName = ShapeName.TargetSelect;
    }
}
