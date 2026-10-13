using UnityEngine;

public class LevelStatus
{
    int controlledUnits;
    int enemyUnits;
    int enemyAlive;
    int alliesAlive;
    public bool phase;
    public LevelStatus(int allies, int enemies)
    {
        alliesAlive = allies;
        enemyAlive = enemies;
        phase = true;
        controlledUnits = allies;
    }
    public void switchPhase()
    {
        if(phase)
        {
            phase = false;
            enemyUnits = enemyAlive;
        }
        else
        {
            phase = true;
            controlledUnits = alliesAlive;
        }
    }
    public void decreasAlive(Unit unit)  
    {
        if(unit.tag.Equals("Player"))
        {
            alliesAlive--;
        }
        else
        {
            enemyAlive--;
        }
    }
    public void decrease(Unit unit)
    {
        if(unit.tag.Equals("Player"))
        {
            controlledUnits -= 1;
            if(controlledUnits == 0)
            {
                switchPhase();

            }
        }
        else
        {
            enemyUnits -= 1;
            if(enemyUnits == 0)
            {
                switchPhase();
            }
        }
    }
}
