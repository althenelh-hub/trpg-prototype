using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class TaskUnit
{
    Unit[] controlled;
    int combatAbility;
    public Decision compareStrength(Unit[] playerControlled)
    {
        int maxStrength = 0;
        foreach (Unit unit in playerControlled) {
            //maxStrength += unit.combatAbility;  
        }
        if(combatAbility > maxStrength)
        {
            return Decision.Engage;
        }
        else
        {
            return Decision.Regroup;
        }
    }
    public Decision compareDistanceToAlly()
    {
        return Decision.Regroup;
    }
}
