using UnityEngine;

public class InflictDamage : SkillEffects
{
    public int damage;
    public InflictDamage(int _damage)
    {
        damage = _damage;
    }
    public override void affect(Unit initiator, Unit target, int compatability, SkillDirection direction)
    {
        Equipment equipment = target.GetComponent<Equipment>();
        equipment.receiveDamage(damage*compatability, direction);
    }
}
