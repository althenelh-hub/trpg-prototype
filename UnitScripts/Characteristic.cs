using UnityEngine;

public class Characteristic
{
    int maxValue;
    int currentValue;
    public Characteristic(int maxValue)
    {
        this.maxValue = maxValue;
        currentValue = maxValue;
    }
    public void decrease(int value)
    {
        currentValue -= value;
    }
    public void increase(int value)
    {
        currentValue += value;
        currentValue -= currentValue % maxValue;
    }
    public int getCurrentValue()
    {
        return currentValue;
    }
    public int getMaxValue()
    {
        return maxValue;
    }
}
