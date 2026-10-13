using UnityEngine;

public class Unit : MapObject
{
    public bool isActive;
    public bool Dead = false;
    public bool knocked;
    public GameClass gameClass;
    public override string ToString()
    {
        return transform.position.ToString();
    }
    public GameClass GetGameClass()
    {
        return gameClass;
    }
    public void activate()
    {
        Stats stats = GetComponent<Stats>();
        if (stats.weight.getMaxValue() < stats.weight.getCurrentValue())
        {
            stats.stamina.decrease(stats.weight.getCurrentValue() - stats.weight.getMaxValue());
        }
        if (knocked)
        {
            knocked = false;
            return;
        }
        isActive = true;
    }
}
