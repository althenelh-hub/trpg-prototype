using System.Collections.Generic;
using UnityEngine;
public enum StanceName
{
    BaseStance,
    OffensiveStance
}

public class GameClass
{
    public Skill[] currentStance;
    WeaponType[] weaponTypes;
    public Dictionary<SkillDirection, int> perceptionRequirment = new Dictionary<SkillDirection, int>();
    public void setStance(Skill[] stance)
    {
        currentStance = stance;
    }
    public int checkDirection(SkillDirection direction)
    {
        return perceptionRequirment[direction];
    }
}
