using UnityEngine;

public class SkillRequirements
{
    public void reduceStats(Stats stats)
    {
        stats.stamina.decrease(20);
    }
}
